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

namespace DefectsDMS
{
    public partial class Form1 : Form
    {
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
                SetColumnsSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetColumnsSettings()
        {
            dataGridViewMain.Columns[0].HeaderText = "Название";
            dataGridViewMain.Columns[1].HeaderText = "Тип";
            dataGridViewMain.Columns[2].HeaderText = "Высота"; dataGridViewMain.Columns[2].Width = 63; //Заглушка
            dataGridViewMain.Columns[3].HeaderText = "Ширина"; dataGridViewMain.Columns[3].Width = 63;
            dataGridViewMain.Columns[4].HeaderText = "Глубина"; dataGridViewMain.Columns[4].Width = 63;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            sqlCon.Open();

            GetDataFromDB("SELECT photo_name, type, heigh, width, depth FROM photo_table, type_table, characteristics_table WHERE " +
                "type_table.type_id = photo_table.type_id AND characteristics_table.characteristics_id = photo_table.characteristics_id");            
        }       
        private void ProgramClose() { sqlCon.Close(); Application.Exit(); }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => ProgramClose();    
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => ProgramClose();        
    }
}
