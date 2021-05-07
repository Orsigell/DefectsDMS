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
    public partial class Form1 : Form
    {
        const string clear = "";
        string photoName;
        SqlConnection sqlCon = null;
        SqlDataAdapter sqlAdapter = null;
        DataTable table = new DataTable();
        public Form1()
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
            dgv.Columns[3].HeaderText = "Высота"; dgv.Columns[2].Width = 63; //Заглушка
            dgv.Columns[4].HeaderText = "Ширина"; dgv.Columns[3].Width = 63;
            dgv.Columns[5].HeaderText = "Глубина"; dgv.Columns[4].Width = 63;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            sqlCon.Open();

            GetDataFromDB("SELECT photo_id, photo_name, type, heigh, width, depth FROM photo_table, type_table, characteristics_table WHERE " +
                "type_table.type_id = photo_table.type_id AND characteristics_table.characteristics_id = photo_table.characteristics_id");
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
            if (dataGridViewSec.SelectedCells.Count >= 1)
            {
                LoadPictureToPictureBox(dataGridViewSec[0, dataGridViewSec.SelectedCells[0].RowIndex].Value.ToString());
                photoName = dataGridViewSec[1, dataGridViewSec.SelectedCells[0].RowIndex].Value.ToString();
            }
        }
        private void dataGridViewMain_CellClick(object sender, DataGridViewCellEventArgs e) //клик на основную таблицу
        {
            dataGridViewSec.ClearSelection();
            if (dataGridViewMain.SelectedCells.Count >= 1)
            {
                LoadPictureToPictureBox(dataGridViewMain[0, dataGridViewMain.SelectedCells[0].RowIndex].Value.ToString());
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
            for (int i = 1; i < 6; i++)
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
            if(pictureBoxMain.Image == null)
            {
                MessageBox.Show("Выберите изображение из таблицы", "Изображение не выбрано", MessageBoxButtons.OK);
                return;
            }
            List <PDFCreator.FilterResult> imageList = new List<PDFCreator.FilterResult>();
            imageList.Add(new PDFCreator.FilterResult(photoName, pictureBoxMain.Image));
            if(checkBox1Negative.Checked)
            {
                imageList.Add(new PDFCreator.FilterResult(checkBox1Negative.Text,ImageFilter.Negative(pictureBoxMain.Image)));
            }
            if(checkBox2Defect.Checked)
            {
                imageList.Add(new PDFCreator.FilterResult(checkBox2Defect.Text, ImageFilter.HighlightingDefect(pictureBoxMain.Image)));
            }
            if(checkBox3Histo.Checked)
            {
                ImageFilter.HistogramsRGBL hist = ImageFilter.BarGraph(pictureBoxMain.Image, 1600, 100);
                if(R.Checked)
                {
                    imageList.Add(new PDFCreator.FilterResult(checkBox3Histo.Text, hist.RedHistogram));
                }
                if (G.Checked)
                {
                    imageList.Add(new PDFCreator.FilterResult(checkBox3Histo.Text, hist.GreenHistogram));
                }
                if (B.Checked)
                {
                    imageList.Add(new PDFCreator.FilterResult(checkBox3Histo.Text, hist.BlueHistogram));
                }
                if (L.Checked)
                {
                    imageList.Add(new PDFCreator.FilterResult(checkBox3Histo.Text, hist.LumHistogram));
                }
            }
            if(checkBoxSegment.Checked)
            {
                imageList.Add(new PDFCreator.FilterResult(checkBoxSegment.Text, ImageFilter.Segmentation(pictureBoxMain.Image, trackBarSegment.Value)));
            }
            if(checkBoxSmooth.Checked)
            {
                imageList.Add(new PDFCreator.FilterResult(checkBoxSmooth.Text, ImageFilter.ImageSmoothing(pictureBoxMain.Image, trackBarSmooth.Value)));
            }
            PDFCreator.CreateDocument(imageList.ToArray());
            System.Diagnostics.Process.Start(PDFCreator.filename); //открытие файла
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
    }
}
