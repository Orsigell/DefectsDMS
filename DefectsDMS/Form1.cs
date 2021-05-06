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
        private void ProgramClose() { sqlCon.Close(); Application.Exit(); }
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
            if (dataGridViewSec.SelectedCells.Count >= 1)
                LoadPictureToPictureBox(dataGridViewSec[0, dataGridViewSec.SelectedCells[0].RowIndex].Value.ToString());
        }
        private void dataGridViewMain_CellClick(object sender, DataGridViewCellEventArgs e) //клик на основную таблицу
        {
            if (dataGridViewMain.SelectedCells.Count >= 1)
                LoadPictureToPictureBox(dataGridViewMain[0, dataGridViewMain.SelectedCells[0].RowIndex].Value.ToString());
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
    }
}
