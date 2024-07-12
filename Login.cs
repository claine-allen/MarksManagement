using System;
using System.Windows.Forms;
using OfficeOpenXml;

namespace MarksManagement
{
        public partial class Login : Form
        {
        private string FilePath= "F:\\Projects\\Pizzeria Goesa\\MarksManagement\\ExcelDatabaseFiles\\LoginDetails.xlsx";
        public Login()
            {
                InitializeComponent();
            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void label4_Click(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {
                string username = textBox1.Text;
                string password = textBox2.Text;

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                if (ValidateCredentials(username, password))
                {
                   // MessageBox.Show("Login Successful!");
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            }

            private bool ValidateCredentials(string username, string password)
            {
                using (var package = new ExcelPackage(new FileInfo(FilePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string excelUsername = worksheet.Cells[row, 1].Value?.ToString();
                        string excelPassword = worksheet.Cells[row, 2].Value?.ToString();

                        if (excelUsername == username && excelPassword == password)
                        {
                            return true;
                        }
                    }
                    return false;

                }
            }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register(FilePath);
            register.ShowDialog();
        }
    }


}


