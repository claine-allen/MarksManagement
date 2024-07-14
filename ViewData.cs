using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;


namespace MarksManagement
{
    public partial class ViewData : Form
    {
        public ViewData()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "F:\\Projects\\Pizzeria Goesa\\MarksManagement\\ExcelDatabaseFiles\\Marks.xslx";
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=YES;'";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    string sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                    string selectQuery = "SELECT * FROM [" + sheetName + "]";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(selectQuery, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
