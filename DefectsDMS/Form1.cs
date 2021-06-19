using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace DefectsDMS
{
    public partial class MainForm : Form
    {
        const string clear = "";
        string photoName;
        SqlConnection sqlCon = null;
        SqlDataAdapter sqlAdapter = null;
        DataTable table = new DataTable();
        const int columnsCount = 4;
        string globalID = "";
        public MainForm()
        {          
            InitializeComponent();
        }
        private void GetDataFromDB(string command)
        {
            try
            {
                sqlAdapter = new SqlDataAdapter(command, sqlCon);
                table.Clear();
                sqlAdapter.Fill(table);
                dataGridViewMain.DataSource = table;
                SetColumnsSettings(dataGridViewMain);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
        private void SetColumnsSettings(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Название";
            dgv.Columns[2].HeaderText = "Тип";
            dgv.Columns[3].HeaderText = "Описание"; dgv.Columns[2].Width = 153; //Заглушка
            //dgv.Columns[4].HeaderText = "Ширина"; dgv.Columns[3].Width = 63;
            //dgv.Columns[5].HeaderText = "Глубина"; dgv.Columns[4].Width = 63;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=true");
            sqlCon.Open();

            GetDataFromDB("SELECT photo_id, photo_name, type, description FROM photo_table, type_table WHERE " +
                "type_table.type_id = photo_table.type_id"); // AND characteristics_table.characteristics_id = photo_table.characteristics_id
            UpdateTypesToComboBox();
        }
        /// <summary>
        /// Загрузка картинки из БД
        /// </summary>
        /// <param name="idvalue">Значение ID</param>
        private void LoadPictureToPictureBox(string idvalue)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT photo FROM photo_table WHERE photo_id = "+ idvalue +"", sqlCon));
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                
                Byte[] data = new Byte[0];
                data = (Byte[])(dataSet.Tables[0].Rows[0]["photo"]);
                MemoryStream mem = new MemoryStream(data);
                pictureBoxMain.Image = Image.FromStream(mem);
            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }
        private void ProgramClose() { sqlCon.Close(); Application.Exit(); File.Delete(PDFCreator.filename); }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => ProgramClose();    
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => ProgramClose();
        private static void ShowError(Exception ex) => MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        /// <summary>
        /// Событие выбора ячейки dataGridViewMain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void dataGridViewSec_CellClick(object sender, DataGridViewCellEventArgs e) //клик на поисковую таблицу
        {
            dataGridViewMain.ClearSelection();
            globalID = dataGridViewSec[0, dataGridViewSec.SelectedCells[0].RowIndex].Value.ToString();
            if (dataGridViewSec.SelectedCells.Count >= 1)
            {
                LoadPictureToPictureBox(globalID);
                photoName = dataGridViewSec[1, dataGridViewSec.SelectedCells[0].RowIndex].Value.ToString();
            }
        }
        private void dataGridViewMain_CellClick(object sender, DataGridViewCellEventArgs e) //клик на основную таблицу
        {
            dataGridViewSec.ClearSelection();
            globalID = dataGridViewMain[0, dataGridViewMain.SelectedCells[0].RowIndex].Value.ToString();
            if (dataGridViewMain.SelectedCells.Count >= 1)
            {
                LoadPictureToPictureBox(globalID);
                photoName = dataGridViewMain[1, dataGridViewMain.SelectedCells[0].RowIndex].Value.ToString();
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == null || toolStripTextBox1.Text == clear) //сброс поисковика если поле пустое
            {
                ShowMainDGV();
                return;
            }
            dataGridViewSec.ColumnCount = dataGridViewMain.ColumnCount;
            dataGridViewSec.RowCount = 1;
            dataGridViewSec.Columns[0].Visible = false;
            for (int i = 0; i < dataGridViewMain.RowCount; i++)
            {
                for (int j = 1; j < dataGridViewMain.ColumnCount; j++)
                {
                    if (dataGridViewMain[j, i].Value.ToString().ToLower().Contains(toolStripTextBox1.Text.ToLower()))
                    {                        
                        for (int k = 0; k < dataGridViewMain.ColumnCount; k++)
                        {
                            dataGridViewSec[k, dataGridViewSec.RowCount - 1].Value = dataGridViewMain[k, i].Value;  
                        }
                        dataGridViewSec.RowCount++;
                        break;
                    }
                }
            }
            if (dataGridViewSec.RowCount == 1)
            {
                MessageBox.Show("Искомые данные отсутствуют в таблице.", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            dataGridViewMain.Visible = false; this.dataGridViewSec.Visible = true;
            dataGridViewSec.RowCount--;
            for (int i = 1; i < columnsCount; i++)
            {
                dataGridViewSec.Columns[i].HeaderText = dataGridViewMain.Columns[i].HeaderText;
            }
            SetColumnsSettings(dataGridViewSec);
        } //вызов процесса поиска по строке

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            ShowMainDGV();
        } //Сброс поисковика по кнопке

        private void ShowMainDGV()
        {
            dataGridViewSec.Visible = false; dataGridViewMain.Visible = true;
            toolStripTextBox1.Text = clear;
        }

        private void trackBarSegment_ValueChanged(object sender, EventArgs e)
        {
            labelSegment.Text = trackBarSegment.Value.ToString();
        } //trackbar1

        private void trackBarSmooth_ValueChanged(object sender, EventArgs e)
        {
            labelSmooth.Text = trackBarSmooth.Value.ToString();
        } //trackbar2

        private void checkBox3Histo_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3Histo.Checked)
            {
                R.Visible = true; G.Visible = true; B.Visible = true; L.Visible = true;
            }
            else
            {
                R.Checked = false; G.Checked = false; B.Checked = false; L.Checked = false;
                R.Visible = false; G.Visible = false; B.Visible = false; L.Visible = false;
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            
            Image tmpimage;
                                   
            if (pictureBoxMain.Image == null)
            {
                MessageBox.Show("Выберите изображение из таблицы", "Изображение не выбрано", MessageBoxButtons.OK);
                return;
            }
            try
            {
                List<PDFCreator.FilterResult> imageList = new List<PDFCreator.FilterResult>();
                imageList.Add(new PDFCreator.FilterResult(photoName, pictureBoxMain.Image));
                if (checkBox1Negative.Checked)
                {
                    tmpimage = ImageFilter.Negative(pictureBoxMain.Image);
                    imageList.Add(new PDFCreator.FilterResult(checkBox1Negative.Text, tmpimage));
                    LoadFilteredPhotoToDB(tmpimage, "photo_negative");
                }
                if (checkBox2Defect.Checked)
                {
                    tmpimage = ImageFilter.HighlightingDefect(pictureBoxMain.Image);
                    imageList.Add(new PDFCreator.FilterResult(checkBox2Defect.Text, tmpimage));
                    LoadFilteredPhotoToDB(tmpimage, "photo_highlight");
                }
                if (checkBox3Histo.Checked)
                {
                    ImageFilter.HistogramsRGBL hist = ImageFilter.BarGraph(pictureBoxMain.Image, 1600, 100);
                    if (R.Checked)
                    {
                        tmpimage = hist.RedHistogram;
                        imageList.Add(new PDFCreator.FilterResult(checkBox3Histo.Text, tmpimage));
                        LoadFilteredPhotoToDB(tmpimage, "photo_histoR");
                    }
                    if (G.Checked)
                    {
                        tmpimage = hist.GreenHistogram;
                        imageList.Add(new PDFCreator.FilterResult(checkBox3Histo.Text, tmpimage));
                        LoadFilteredPhotoToDB(tmpimage, "photo_histoG");
                    }
                    if (B.Checked)
                    {
                        tmpimage = hist.BlueHistogram;
                        imageList.Add(new PDFCreator.FilterResult(checkBox3Histo.Text, tmpimage));
                        LoadFilteredPhotoToDB(tmpimage, "photo_histoB");
                    }
                    if (L.Checked)
                    {
                        tmpimage = hist.LumHistogram;
                        imageList.Add(new PDFCreator.FilterResult(checkBox3Histo.Text, tmpimage));
                        LoadFilteredPhotoToDB(tmpimage, "photo_histoL");
                    }
                }
                if (checkBoxSegment.Checked)
                {
                    tmpimage = ImageFilter.Segmentation(pictureBoxMain.Image, trackBarSegment.Value);
                    imageList.Add(new PDFCreator.FilterResult(checkBoxSegment.Text, tmpimage));
                    LoadFilteredPhotoToDB(tmpimage, "photo_segment");
                }
                if (checkBoxSmooth.Checked)
                {
                    tmpimage = ImageFilter.ImageSmoothing(pictureBoxMain.Image, trackBarSmooth.Value);
                    imageList.Add(new PDFCreator.FilterResult(checkBoxSmooth.Text, tmpimage));
                    LoadFilteredPhotoToDB(tmpimage, "photo_smooth");
                }
                if (gaussianBlurCheckBox.Checked)
                {
                    tmpimage = ImageFilter.GaussianBlur(pictureBoxMain.Image);
                    imageList.Add(new PDFCreator.FilterResult(gaussianBlurCheckBox.Text, tmpimage));
                    LoadFilteredPhotoToDB(tmpimage, "photo_gauss");
                }
                PDFCreator.CreateDocument(imageList.ToArray());
                System.Diagnostics.Process.Start(PDFCreator.filename); //открытие файла
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void LoadFilteredPhotoToDB(Image tmpimage, string photoColumn)
        {
            MemoryStream memoryStream = new MemoryStream();
            tmpimage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] image = memoryStream.ToArray();
            SqlCommand sqlCommand = new SqlCommand($"UPDATE photo_table SET {photoColumn} = @Image WHERE photo_id = {globalID}", sqlCon);
            sqlCommand.Parameters.AddWithValue("@Image", image);
            sqlCommand.ExecuteNonQuery();
        }

        private void СохранитьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(PDFCreator.filename))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Сохранить как файл PDF";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    File.Copy(PDFCreator.filename, saveFileDialog.FileName, true);
                }
            }
            else
            {
                MessageBox.Show("Не сформирован отчёт для сохранения", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void открытьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(PDFCreator.filename))
            {
                System.Diagnostics.Process.Start(PDFCreator.filename);
            }
            else
            {
                MessageBox.Show("Ни один отчёт не был сформирован", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getPhotoFromDB_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCom = new SqlCommand("SELECT max(photo_id) FROM photo_table", sqlCon);
                int maxid = (int)sqlCom.ExecuteScalar();
                GetColumnPhotoFromDB(maxid, "photo", "");
                GetColumnPhotoFromDB(maxid, "photo_negative", "_Негатив");
                GetColumnPhotoFromDB(maxid, "photo_highlight", "_Выделение дефекта");
                GetColumnPhotoFromDB(maxid, "photo_histoR", "_Гистограмма красного цвета");
                GetColumnPhotoFromDB(maxid, "photo_histoG", "_Гистограмма зелёного цвета");
                GetColumnPhotoFromDB(maxid, "photo_histoB", "_Гистограмма красного цвета");
                GetColumnPhotoFromDB(maxid, "photo_histoL", "_Гистограмма красного цвета");
                GetColumnPhotoFromDB(maxid, "photo_segment", "_Сегментация");
                GetColumnPhotoFromDB(maxid, "photo_smooth", "_Фильтрация");
                GetColumnPhotoFromDB(maxid, "photo_gauss", "_Фильтр Гаусса");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void GetColumnPhotoFromDB(int maxid, string photo, string fileName)
        {
            for (int i = 1; i <= maxid; i++)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand($"SELECT {photo} FROM photo_table where photo_id = {i}", sqlCon));
                SqlCommand sqlCom = new SqlCommand($"Select photo_name FROM photo_table WHERE photo_id = {i}", sqlCon);
                string filename = (string)sqlCom.ExecuteScalar();
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                try
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dataSet.Tables[0].Rows[0][photo]);
                    if (!Directory.Exists(@"DataSet"))
                    {
                        Directory.CreateDirectory(@"DataSet");
                    }
                    if (data.Length != 0)
                    {
                        MemoryStream mem = new MemoryStream(data);
                        File.WriteAllBytes($@"DataSet\{filename}{fileName}.jpg", mem.ToArray());
                        //Image tmpImage = Image.FromStream(mem);
                        //tmpImage.Save($@"DataSet\{filename}");   
                    }
                }
                catch {}
            }
        }

        private void UpdateTypesToComboBox()
        {
            comboBoxType.Items.Clear();
            SqlCommand sqlCommand = new SqlCommand("Select type from type_table", sqlCon);
            using (SqlDataReader rdr = sqlCommand.ExecuteReader())
            {
                while (rdr.Read())
                {
                    comboBoxType.Items.Add(rdr["type"]);
                }
            }
        }

        private void textBoxDescr_Enter(object sender, EventArgs e)
        {
            textBoxTypeDescr.Text = "";
        }

        private void textBoxDescr_Leave(object sender, EventArgs e)
        {
            if(textBoxTypeDescr.Text == "")
            textBoxTypeDescr.Text = "Описание";
        }

        private void textBoxTypeName_Leave(object sender, EventArgs e)
        {
            if(textBoxTypeName.Text == "")
            textBoxTypeName.Text = "Название";
        }

        private void textBoxTypeName_Enter(object sender, EventArgs e)
        {
            textBoxTypeName.Text = "";
        }

        private void buttonTypeAdd_Click(object sender, EventArgs e)
        {
            if (textBoxTypeName.Text != "Название" && textBoxTypeDescr.Text != "Описание")
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("addType", sqlCon);
                    sqlCommand.Parameters.AddWithValue("@type", textBoxTypeName.Text);
                    sqlCommand.Parameters.AddWithValue("@description", textBoxTypeDescr.Text);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    int tmp = sqlCommand.ExecuteNonQuery();
                    UpdateTypesToComboBox();
                    //SqlCommand sqlCommand = new SqlCommand("INSERT INTO type_table (type, description) VALUES (N'" + textBoxTypeName.Text + "', N'" + textBoxTypeDescr.Text + "')", sqlCon);
                    //sqlCommand.ExecuteNonQuery();
                    ////DataSet dataSet = new DataSet();
                    ////dataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Данные введены некорректно.", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void textBoxPhotoName_Enter(object sender, EventArgs e)
        {
            textBoxPhotoName.Text = "";
        }

        private void textBoxPhotoName_Leave(object sender, EventArgs e)
        {
            if (textBoxPhotoName.Text == "")
                textBoxPhotoName.Text = "Название";
        }

        private void buttonPhotoAdd_Click(object sender, EventArgs e)
        {
            if (textBoxPhotoName.Text == "" || textBoxPhotoName.Text == "Название")
            {
                MessageBox.Show("Укажите название фото", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] image;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Файлы изображений (PNG, JPG, JPEG)|*.png;*.jpg;*.jpeg|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выбрать изображение";
                openFileDialog.ShowDialog();
                if (openFileDialog.FileName != "" && File.Exists(openFileDialog.FileName) && comboBoxType.SelectedItem != null)
                {
                    image = File.ReadAllBytes(openFileDialog.FileName);
                    SqlCommand sqlCommand = new SqlCommand($"INSERT INTO photo_table (type_id, photo_name, photo) VALUES " +
                       $"((SELECT type_id FROM type_table WHERE type LIKE N'{comboBoxType.SelectedItem}'), N'{textBoxPhotoName.Text}', @Image)", sqlCon);
                    sqlCommand.Parameters.AddWithValue("@Image", image);
                    sqlCommand.ExecuteNonQuery();
                }
                GetDataFromDB("SELECT photo_id, photo_name, type, description FROM photo_table, type_table WHERE " +
                "type_table.type_id = photo_table.type_id");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }           
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"  Автоматизированая система для работы с дефектоскопическими  изображениями

                                   Разработчик: Цыброва Валерия Сергеевна, 2021","О программе");
        }
    }
}
