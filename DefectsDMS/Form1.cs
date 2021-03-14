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
            sqlAdapter = new SqlDataAdapter(command, sqlCon);
            table.Clear();
            sqlAdapter.Fill(table);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            sqlCon.Open();
        }
        private void ProgramClose() { sqlCon.Close(); Application.Exit(); }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => ProgramClose();    
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => ProgramClose();        
    }
}
