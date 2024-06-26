using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Estate_WindowsForms.TablesForms
{
    public partial class Professions : Form
    {
        public static string tableName = "Professions";
        SQLiteHelper dbHelper = new SQLiteHelper(tableName);
        public Professions(bool isAdmin)
        {
            InitializeComponent();
            LoadData();

            if (isAdmin)
            {
                Size = new System.Drawing.Size(new Point(515, 626));
                AdminPanel.Visible = true;
            }
            else
            {
                Size = new System.Drawing.Size(new Point(515, 440));
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

        private void UpdateSalaryButton_Click(object sender, EventArgs e)
        {
            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, IDtextBox1, SalaryUpdateTextBox))
            {
                if (FieldValidator.ValidateIntFields(out errorMessages, IDtextBox1, SalaryUpdateTextBox))
                {
                    if (dbHelper.UpdateFieldById(IDtextBox1.Text, "Salary", SalaryUpdateTextBox.Text))
                    {
                        MessageBox.Show("Оклад успешно обновлен.");
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
            string query = $@"SELECT * FROM {tableName}
                            WHERE Code = @id";
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

        private void CodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ProfessionNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'а' && e.KeyChar <= 'я' || e.KeyChar == 'ё') //разрешение клавишь а до я, буква ё
                e.Handled = false;
            else if (e.KeyChar >= 'А' && e.KeyChar <= 'Я' || e.KeyChar == 'Ё') //разрешение клавишь а до я, буква ё
                e.Handled = false;
            else if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.ControlKey || e.KeyChar == (char)Keys.Space)
                e.Handled = false;
            else
            {
                e.Handled = true;
            }
        }

        private void AddRow()
        {
            TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel); // Работает если не трогать свойства TextBox

            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, listOfTextBoxes.Skip(1).ToArray()))
            {
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

        private void UpdateArrow()
        {
            TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel);

            if (!string.IsNullOrWhiteSpace(CodeTextBox.Text))
            {
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
            if (dbHelper.RecordExistsByValueTableColumn(Code, "Employees", "ProfessionCode"))
            {
                MessageBox.Show("Запись с этой должностью есть в таблице Employees.\nУдаление невозможно!");
                return;
            }

            if (dbHelper.DeleteRecordById(CodeTextBox.Text))
            {
                LoadData();
                MessageBox.Show("Строка успешно удалена.");
            }
            else
            {
                MessageBox.Show("Такого ID нет!");
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
                    }
                }
            }
        }
    }
}
