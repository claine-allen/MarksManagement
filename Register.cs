using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarksManagement
{
    public partial class Register : Form
    {
        private string FilePath;

        public Register(string filePath)
        {
            InitializeComponent();
            this.FilePath = filePath;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please Fill In All Fields!");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords Do Not Match!");
                return;
            }
            if (UserExists(username))
            {
                MessageBox.Show("Username Already Exists!");
                return;
            }

            using (var package = new ExcelPackage(new FileInfo(FilePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                int lastRow = worksheet.Dimension?.Rows ?? 0;
                int newRow = lastRow + 1;

                worksheet.Cells[newRow, 1].Value = username;
                worksheet.Cells[newRow, 2].Value = password;
                package.Save();

                MessageBox.Show("Registration Successful!");
                this.Close();
            }
        }
        bool UserExists(string username)
        {
            using (var package = new ExcelPackage(new FileInfo(FilePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    string excelUsername = worksheet.Cells[row, 1].Value?.ToString();
                    if (excelUsername == username)
                    {
                        return true;
                    }
                }
            }
            return false;
        }



    }
}
