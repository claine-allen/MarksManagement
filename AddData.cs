using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace MarksManagement
{
    public partial class AddData : Form
    {
        private string filePath = "F:\\Projects\\Pizzeria Goesa\\MarksManagement\\ExcelDatabaseFiles\\Marks.xslx";
        public AddData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rollNumber=textBox1.Text;
            string english=textBox2.Text;
            string hindi = textBox3.Text;
            string konkani=textBox3.Text;
            string mathematics=textBox6.Text;
            string science=textBox5.Text;
            string socialScience = textBox4.Text;

            SaveDataToExcel(rollNumber, english, hindi, konkani, mathematics, science, socialScience);

            this.Close();


        }
        private void SaveDataToExcel(string rollNumber,string english,string hindi,string konkani,string mathematics,string science,string socialScience)
        {
            //string filePath = "F:\\Projects\\Pizzeria Goesa\\MarksManagement\\ExcelDatabaseFiles\\Marks.xslx";

            Excel.Application excelApp=new Excel.Application();
            Excel.Workbook workbook=excelApp.Workbooks.Add();
            Excel.Worksheet worksheet =(Excel.Worksheet) workbook.Worksheets[1];

            int row = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row + 1;

            worksheet.Cells[row,1]=rollNumber;
            worksheet.Cells[row, 2] =english;
            worksheet.Cells[row, 3] =hindi;
            worksheet.Cells[row, 4] = konkani;
            worksheet.Cells[row, 5] = mathematics;
            worksheet.Cells[row, 6] = science;
            worksheet.Cells[row, 7] = socialScience;

            workbook.Save();
            workbook.Close();
            excelApp.Quit();

            MessageBox.Show("Data Saved Successfully!");
        }
    }
}
