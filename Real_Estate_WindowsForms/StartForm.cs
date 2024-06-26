using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;
using System.Diagnostics;
using Real_Estate_WindowsForms.TablesForms;

namespace Real_Estate_WindowsForms
{
    public partial class StartForm : Form
    {
        public static string tableName = "Users";
        SQLiteHelper dbHelper = new SQLiteHelper(tableName); 
        private bool IsAdmin;

        public StartForm()
        {
            InitializeComponent();

            LoginTextBox.Text = "admin";
            PasswordTextBox.Text = "1234";



        }

        public static void RunBatchFile(string filePath)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = filePath;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;

            using (Process process = Process.Start(processInfo))
            {
                process.WaitForExit();
            }
        }

        public void Login()
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text) || string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                string login = LoginTextBox.Text;
                string password = PasswordTextBox.Text;

                string query = "SELECT Password FROM Users WHERE Login = @value";

                // Используем SQLiteHelper для выполнения запроса
                DataTable dt = new SQLiteHelper().FindRecordByValue(query, login);

                // Проверяем результат запроса
                if (dt.Rows.Count > 0)
                {
                    string storedHash = dt.Rows[0]["Password"].ToString();

                    if (PasswordHelper.VerifyPassword(password, storedHash))
                    {
                        IsAdmin = (login == "admin");
                        LoginPanel.Visible = false;
                        return;
                    }
                }

                MessageBox.Show("Неверный логин или пароль.");
            }
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                string query = "SELECT * FROM Users WHERE Login = @value";
                if (dbHelper.FindRecordByValue(query, login).Rows.Count > 0)
                {
                    MessageBox.Show("Такой пользователь уже есть!");
                }
                else
                {
                    // Хэширование пароля перед сохранением в базу данных
                    string hashedPassword = PasswordHelper.HashPassword(password);

                    if (dbHelper.InsertNewUser(login, hashedPassword))
                    {
                        MessageBox.Show("Регистрация прошла успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка во время регистрации!");
                    }

                }
            }
        }

        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void LoginPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (IsAdmin)
            {
                ToUsers.Enabled = true;
            }
        }

        private void OpenForm(Type formType, bool isAdmin)
        {
            Form formToHandle = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.GetType() == formType);

            if (formToHandle != null)
            {
                formToHandle.BringToFront();
            }
            else
            {
                formToHandle = (Form)Activator.CreateInstance(formType, new object[] { isAdmin });
                formToHandle.Show();
            }
        }

        private void ToRealEstate_Click(object sender, EventArgs e) => OpenForm(typeof(RealEstate), IsAdmin);
        private void ToTypeOfRealEstate_Click(object sender, EventArgs e) => OpenForm(typeof(TypeOfRealEstate), IsAdmin);
        private void ToProffessions_Click(object sender, EventArgs e) => OpenForm(typeof(Professions), IsAdmin);
        private void ToPerson_Click(object sender, EventArgs e) => OpenForm(typeof(Person), IsAdmin);
        private void ToEmployees_Click(object sender, EventArgs e) => OpenForm(typeof(Employees), IsAdmin);
        private void ToDeals_Click(object sender, EventArgs e) => OpenForm(typeof(Deals), IsAdmin);
        private void ToDiagram_Click(object sender, EventArgs e) => OpenForm(typeof(Diagram), false); // Диаграмма не требует параметра isAdmin
        private void ToUsers_Click(object sender, EventArgs e) => OpenForm(typeof(Users), false);

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string batchFilePath = @"Crutches/Kill_Real_Estate_process.bat";
            RunBatchFile(batchFilePath);
        }

        private void LoginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'а' && e.KeyChar <= 'я' || e.KeyChar == 'ё') //разрешение клавишь а до я, буква ё
                e.Handled = false;
            else if (e.KeyChar >= 'А' && e.KeyChar <= 'Я' || e.KeyChar == 'Ё') //разрешение клавишь а до я, буква ё
                e.Handled = false;
            else if (e.KeyChar >= 'a' && e.KeyChar <= 'z') //разрешение клавишь а до z
                e.Handled = false;
            else if (e.KeyChar >= 'A' && e.KeyChar <= 'Z') //разрешение клавишь а до z
                e.Handled = false;
            else if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
                e.Handled = false;
            else if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.ControlKey)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }
    }
}
