using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Real_Estate_WindowsForms.TablesForms
{
    public partial class Person : Form
    {
        public static string tableName = "Person";
        SQLiteHelper dbHelper = new SQLiteHelper(tableName);

        public Person(bool isAdmin)
        {
            InitializeComponent();
            LoadData();

            if (isAdmin)
            {
                Size = new System.Drawing.Size(new Point(757, 782));
                AdminPanel.Visible = true;
            }
            else
            {
                Size = new System.Drawing.Size(new Point(711, 487));
                AdminPanel.Enabled = false;
            }
        }

        private void LoadData()
        {
            string query = $"SELECT * FROM {tableName}";

            DataTable dt = dbHelper.DTExecuteQueryDT(query);
            TableDataGridView.DataSource = dt;
        }

        private void UpdateTableBTN_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void UpdatePhoneButton_Click(object sender, EventArgs e)
        {
            FieldValidator.ReplaceValuesMaskedTBtoTB(PhoneUpdateMaskedTextBox, PhoneUpdateTextBox);
            if (!PhoneMaskedTextBox.MaskCompleted)
            {
                MessageBox.Show("Поле номера телефона не заполнено полностью!");
                return;
            }

            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, IDtextBox1, PhoneUpdateTextBox))
            {
                if (FieldValidator.ValidateIntFields(out errorMessages, IDtextBox1))
                {
                    if (dbHelper.UpdateFieldById(IDtextBox1.Text, "Phone", PhoneUpdateTextBox.Text))
                    {
                        MessageBox.Show("Телефон успешно обновлен.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Такого ID нет!");
                    }
                }
                else
                {
                    MessageBox.Show(errorMessages);
                }
            }
            else
            {
                MessageBox.Show(errorMessages);
            }
        }

        private void UpdateEmailButton_Click(object sender, EventArgs e)
        {
            if (!FieldValidator.IsValidEmail(EmailUpdateTextBox.Text))
            {
                MessageBox.Show("Неправильный формат почты!");
                return;
            }
            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, IDtextBox2, EmailUpdateTextBox))
            {
                if (FieldValidator.ValidateIntFields(out errorMessages, IDtextBox2))
                {
                    if (dbHelper.UpdateFieldById(IDtextBox2.Text, "Email", EmailUpdateTextBox.Text))
                    {
                        MessageBox.Show("Почта успешно обновлена.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Такого ID нет!");
                    }
                }
                else
                {
                    MessageBox.Show(errorMessages);
                }
            }
            else
            {
                MessageBox.Show(errorMessages);
            }
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM {tableName} WHERE Code = @id";

            string errorMessage;
            if (FieldValidator.ValidateFields(out errorMessage, IDtextBox3))
            {
                if (FieldValidator.ValidateIntFields(out errorMessage, IDtextBox3))
                {
                    DataTable dt = dbHelper.FindRecordById(query, IDtextBox3.Text);
                    if (dt.Rows.Count >= 1)
                    {
                        TableDataGridView.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Такого ID нет!");
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void AddRow()
        {
            FieldValidator.ReplaceValuesMaskedTBtoTB(BirthDateMaskedTextBox, BirthDateTextBox);
            FieldValidator.ReplaceValuesMaskedTBtoTB(PhoneMaskedTextBox, PhoneTextBox);

            TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel); // Работает если не трогать свойства TextBox

            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, listOfTextBoxes.Skip(1).ToArray()))
            {
                if (FieldValidator.ValidateFields(out errorMessages, BirthDateMaskedTextBox, PhoneMaskedTextBox))//BirthDateMaskedTextBox.MaskCompleted
                {
                    if (!BirthDateMaskedTextBox.MaskCompleted)
                    {
                        MessageBox.Show("Поле даты рождения не заполнено полностью!");
                        return;
                    }
                    if (!FieldValidator.ValidateDateTimeFieldWithAge(out errorMessages, BirthDateTextBox.Text))
                    {
                        MessageBox.Show(errorMessages);
                        return;
                    }
                    if (!PhoneMaskedTextBox.MaskCompleted)
                    {
                        MessageBox.Show("Поле номера телефона не заполнено полностью!");
                        return;
                    }

                    if (!FieldValidator.IsValidEmail(EmailTextBox.Text))
                    {
                        MessageBox.Show("Неправильный формат почты!");
                        return;
                    }

                    if (dbHelper.InsertNewArrow(listOfTextBoxes))
                    {
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("При выполнении возникла ошибка!");
                    }
                }
                else
                {
                    MessageBox.Show(errorMessages);
                }
            }
            else
            {
                MessageBox.Show(errorMessages);
            }
        }

        private void INTtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false; // разрешаем ввод символов
            }
            else
            {
                e.Handled = true; // блокируем ввод остальных символов
            }
        }

        private void UpdateArrow()
        {
            FieldValidator.ReplaceValuesMaskedTBtoTB(BirthDateMaskedTextBox, BirthDateTextBox);
            FieldValidator.ReplaceValuesMaskedTBtoTB(PhoneMaskedTextBox, PhoneTextBox);
            TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel);

            string errorMessages;
            if (!string.IsNullOrWhiteSpace(CodeTextBox.Text))
            {
                if (BirthDateTextBox.Text.Any(char.IsDigit))
                {
                    if (!BirthDateMaskedTextBox.MaskCompleted)
                    {
                        MessageBox.Show("Поле даты рождения не заполнено полностью!");
                        return;
                    }

                    if (!FieldValidator.ValidateDateTimeFieldWithAge(out errorMessages, BirthDateTextBox.Text))
                    {
                        MessageBox.Show(errorMessages);
                        return;
                    }
                }

                if (PhoneTextBox.Text.Substring(2).Any(char.IsDigit))
                {
                    if (!PhoneMaskedTextBox.MaskCompleted)
                    {
                        MessageBox.Show("Поле даты рождения не заполнено полностью!");
                        return;
                    }
                }
                else
                {
                    PhoneTextBox.Text = null;
                }

                if (!string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    if (!FieldValidator.IsValidEmail(EmailTextBox.Text))
                    {
                        MessageBox.Show("Неправильный формат почты!");
                        return;
                    }
                }

                if (dbHelper.UpdateRow(CodeTextBox.Text, listOfTextBoxes))
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("При выполнении возникла ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Заполните поле Code и хотя бы 1 другое.");
            }
        }

        private void ValidateDelete(string Code)
        {
            if (dbHelper.RecordExistsByValueTableColumn(Code, "Deals", "OwnerCode"))
            {
                MessageBox.Show("Запись с этим человеком есть в таблице Deals.\nУдаление невозможно!");
                return;
            }
            if (dbHelper.RecordExistsByValueTableColumn(Code, "Employees", "PersonCode"))
            {
                MessageBox.Show("Запись с этим человеком есть в таблице Employees.\nУдаление невозможно!");
                return;
            }
            if (dbHelper.RecordExistsByValueTableColumn(Code, "RealEstate", "OwnerCode"))
            {
                MessageBox.Show("Запись с этим человеком есть в таблице RealEstate.\nУдаление невозможно!");
                return;
            }

            if (dbHelper.DeleteRecordById(CodeTextBox.Text))
            {
                LoadData();
                MessageBox.Show("Строка успешно удалена.");
            }
            else
            {
                MessageBox.Show("Ошибка при удалении строки.");
            }
        }

        private void DeleteArrow()
        {
            if (TableDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = TableDataGridView.SelectedRows[0];

                // Получаем значение ID строки для удаления
                string Code = selectedRow.Cells["Code"].Value.ToString();

                ValidateDelete(Code);
            }
            else
            {
                string errorMessages;
                if (FieldValidator.ValidateFields(out errorMessages, CodeTextBox))
                {
                    ValidateDelete(CodeTextBox.Text);
                }
                else
                {
                    MessageBox.Show(errorMessages);
                }
            }
        }

        private void ClearColumnsFieldsButton_Click(object sender, EventArgs e)
        {
            FieldValidator.ClearTextBoxes(this);
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel);
            MaskedTextBox[] listOfMaskedTextBoxes = FieldValidator.FindMaskedTextBoxesColumnsPanel(ColumnsPanel);

            if (radioButton1.Checked)
            {
                listOfTextBoxes[0].Enabled = false;
                foreach (TextBox textBox in listOfTextBoxes.Skip(1).ToArray())
                {
                    textBox.Enabled = true;
                }
                foreach (MaskedTextBox textBox in listOfMaskedTextBoxes)
                {
                    textBox.Enabled = true;
                }
            }
            else if (radioButton2.Checked)
            {
                foreach (TextBox textBox in listOfTextBoxes)
                {
                    textBox.Enabled = true;
                }
                foreach (MaskedTextBox textBox in listOfMaskedTextBoxes)
                {
                    textBox.Enabled = true;
                }
            }
            else if (radioButton3.Checked)
            {
                listOfTextBoxes[0].Enabled = true;
                foreach (TextBox textBox in listOfTextBoxes.Skip(1).ToArray())
                {
                    textBox.Enabled = false;
                }
                foreach (MaskedTextBox textBox in listOfMaskedTextBoxes)
                {
                    textBox.Enabled = false;
                }
            }
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                AddRow();
            }
            else if (radioButton2.Checked)
            {
                UpdateArrow();
            }
            else if (radioButton3.Checked)
            {
                // Если пользователь выбрал строку для удаления или введено значение в CodeTextBox
                if (TableDataGridView.SelectedRows.Count > 0 || !string.IsNullOrWhiteSpace(CodeTextBox.Text))
                {
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную строку?", "Удаление строки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    // Если пользователь подтвердил удаление
                    if (result == DialogResult.Yes) DeleteArrow();
                }
                else
                {
                    MessageBox.Show("Выберите строку для удаления или введите значение в поле Code.");
                }
            }
            else
            {
                MessageBox.Show("Выберите режим!");
            }
        }

        private void TableDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (TableDataGridView.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку
                DataGridViewRow selectedRow = TableDataGridView.SelectedRows[0];

                // Получаем список столбцов из таблицы данных
                var columns = selectedRow.DataGridView.Columns.Cast<DataGridViewColumn>()
                                   .Select(x => x.Name)
                                   .ToList();

                TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel);
                foreach (var textBox in listOfTextBoxes)
                {
                    // Получаем имя поля из имени TextBox
                    string fieldName = FieldValidator.GetTextBoxName(textBox);

                    // Если имя поля присутствует в списке столбцов таблицы данных
                    if (columns.Contains(fieldName))
                    {
                        // Получаем индекс столбца в выбранной строке
                        int columnIndex = selectedRow.DataGridView.Columns[fieldName].Index;

                        // Получаем значение ячейки из выбранной строки и столбца
                        string cellValue = selectedRow.Cells[columnIndex].Value.ToString();

                        // Обновляем значение TextBox
                        textBox.Text = cellValue;

                        if (textBox.Name == "BirthDateTextBox")
                        {
                            // Парсинг строки даты с использованием точного формата
                            DateTime date = DateTime.ParseExact(textBox.Text, "dd.MM.yyyy H:mm:ss", null);
                            // Форматирование даты в нужный формат
                            string formattedDate = date.ToString("yyyy-MM-dd");
                            BirthDateMaskedTextBox.Text = formattedDate;
                        }

                        else if (textBox.Name == "PhoneTextBox")
                        {
                            FieldValidator.ReplaceValuesTBtoMaskedTB(textBox, PhoneMaskedTextBox);
                        }
                    }
                }
            }
        }

    }
}
