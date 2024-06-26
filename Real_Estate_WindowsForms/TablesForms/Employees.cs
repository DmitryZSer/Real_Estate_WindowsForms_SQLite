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
    public partial class Employees : Form
    {
        public static string tableName = "Employees";
        SQLiteHelper dbHelper = new SQLiteHelper(tableName);
        public Employees(bool isAdmin)
        {
            InitializeComponent();
            LoadData();

            if (isAdmin)
            {
                Size = new System.Drawing.Size(new Point(545, 613));
                AdminPanel.Visible = true;
            }
            else
            {
                Size = new System.Drawing.Size(new Point(545, 445));
                AdminPanel.Enabled = false;
            }
        }
        private void LoadData()
        {
            bool displayTextValues = TextValuecheckBox.Checked;

            string query;

            if (displayTextValues)
            {
                // Запрос с подстановкой текстовых значений
                query = @"
        SELECT
            em.PersonCode AS 'Код человека',
            p.FirstName || ' ' || p.LastName AS Человек,
            ProfessionCode AS 'Код профессии',
            pro.ProfessionName as 'Название профессии'
        FROM Employees em
        JOIN Professions pro ON em.ProfessionCode = pro.Code
        JOIN Person p ON em.PersonCode = p.Code";
            }
            else
            {
                // Запрос для получения данных напрямую
                query = $"SELECT  *  FROM Employees;";
            }

            DataTable dt = dbHelper.DTExecuteQueryDT(query);
            TableDataGridView.DataSource = dt;
        }

        private void TextValuecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void UpdateTableBTN_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Int_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ClearColumnsFieldsButton_Click(object sender, EventArgs e)
        {
            FieldValidator.ClearTextBoxes(this);
        }

        private void UpdateProfessionButton_Click(object sender, EventArgs e)
        {
            
        }

        private void SearchBTN2_Click(object sender, EventArgs e)
        {
            string query = $@"
            SELECT
            em.PersonCode,
            p.FirstName || ' ' || p.LastName AS Person,
            em.ProfessionCode,
            pro.ProfessionName as ProfessionName
        FROM Employees em
        JOIN Professions pro ON em.ProfessionCode = pro.Code
        JOIN Person p ON em.PersonCode = p.Code
            WHERE p.Code = @id";
            string errorMessage;
            if (FieldValidator.ValidateFields(out errorMessage, IDtextBox2))
            {
                DataTable dt = dbHelper.FindRecordById(query, IDtextBox2.Text);
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
        private void SearchBTN3_Click(object sender, EventArgs e)
        {
            string query = $@"
            SELECT
            em.PersonCode,
            p.FirstName || ' ' || p.LastName AS Person,
            em.ProfessionCode,
            pro.ProfessionName as ProfessionName
        FROM Employees em
        JOIN Professions pro ON em.ProfessionCode = pro.Code
        JOIN Person p ON em.PersonCode = p.Code
            WHERE pro.Code = @id";
            string errorMessage;
            if (FieldValidator.ValidateFields(out errorMessage, IDtextBox3))
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

        private void AddRow()
        {
            TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel); // Работает если не трогать свойства TextBox

            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, listOfTextBoxes))
            {
                if (!dbHelper.RecordExistsByValueTableColumn(PersonCodeTextBox.Text, "Person", "Code"))
                {
                    MessageBox.Show("Запись из таблицы Person с таким Code не существует!");
                    return;
                }

                if (!dbHelper.RecordExistsByValueTableColumn(ProfessionCodeTextBox.Text, "Professions", "Code"))
                {
                    MessageBox.Show("Запись из таблицы Professions с таким Code не существует!");
                    return;
                }

                if (dbHelper.RecordExistsByValueTableColumn(PersonCodeTextBox.Text, tableName, "PersonCode"))
                {
                    MessageBox.Show("Такой сотрудник уже записан!\nВы можете поменять ему должность.");
                    return;
                }

                if (dbHelper.InsertNewArrowTableWithNoCode(listOfTextBoxes))
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

            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, listOfTextBoxes))
            {
                if (!dbHelper.RecordExistsByValueTableColumn(ProfessionCodeTextBox.Text, "Professions", "Code"))
                {
                    MessageBox.Show("Запись из таблицы Professions с таким Code не существует!");
                    return;
                }

                if (dbHelper.UpdateFieldById(PersonCodeTextBox.Text, "ProfessionCode", ProfessionCodeTextBox.Text, "PersonCode"))
                {
                    MessageBox.Show("Должность успешно обновлена.");
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

        private void ValidateDelete(string Code)
        {
            if (dbHelper.RecordExistsByValueTableColumn(Code, "Deals", "EmployeeCode"))
            {
                MessageBox.Show("Запись с этим работником есть в таблице Deals.\nУдаление невозможно!");
                return;
            }

            if (dbHelper.DeleteRecordById(Code, "PersonCode"))
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
                string Code = selectedRow.Cells["PersonCode"].Value.ToString();

                ValidateDelete(Code);
            }
            else
            {
                string errorMessages;
                if (FieldValidator.ValidateFields(out errorMessages, PersonCodeTextBox))
                {
                    ValidateDelete(PersonCodeTextBox.Text);
                }
                else
                {
                    MessageBox.Show(errorMessages);
                }
            }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel);
            MaskedTextBox[] listOfMaskedTextBoxes = FieldValidator.FindMaskedTextBoxesColumnsPanel(ColumnsPanel);

            if (radioButton1.Checked)
            {
                listOfTextBoxes[0].Enabled = false;
                foreach (TextBox textBox in listOfTextBoxes)
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
                if (TableDataGridView.SelectedRows.Count > 0 || !string.IsNullOrWhiteSpace(PersonCodeTextBox.Text))
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
