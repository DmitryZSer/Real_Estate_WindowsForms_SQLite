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
    public partial class Deals : Form
    {
        public static string tableName = "Deals";
        SQLiteHelper dbHelper = new SQLiteHelper(tableName);

        public Deals(bool isAdmin)
        {
            InitializeComponent();

            LoadData();

            if (isAdmin)
            {
                Size = new System.Drawing.Size(new Point(803, 800));
                AdminPanel.Visible = true;
            }
            else
            {
                Size = new System.Drawing.Size(new Point(803, 546));
                AdminPanel.Enabled = false;
            }
        }
        private void LoadData()
        {
            bool displayTextValues = TextValuecheckBox.Checked;

            string query;

            if (displayTextValues)
            {//pr.ProfessionName AS EmployeeProfession,
                // Запрос с подстановкой текстовых значений
               query = @"
        SELECT 
   d.Code,
    d.DealDate,    
    d.EmployeeCode,
    p.FirstName || ' ' || p.LastName AS Сотрудник,
    o.FirstName || ' ' || o.LastName AS `Владелец недвижимости`,
    d.RealEstateCode,
    d.Commission,
    trt.NameOfTheRealEstateType AS `Тип недвижимости`
FROM 
    Deals d
JOIN
    Employees e ON d.EmployeeCode = e.PersonCode
JOIN
    Person p ON e.PersonCode = p.Code
JOIN
    RealEstate re ON d.RealEstateCode = re.Code
JOIN
    Person o ON re.OwnerCode = o.Code
JOIN
    TypeOfRealEstate trt ON re.TypeOfRealEstateCode = trt.Code";

            }
            else
            {
                // Запрос для получения данных напрямую
                query = $"SELECT * FROM {tableName}";
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

        private void SearchBTN1_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
   d.Code,
    d.DealDate,    
    d.EmployeeCode,
    p.FirstName || ' ' || p.LastName AS Сотрудник,
    o.FirstName || ' ' || o.LastName AS `Владелец недвижимости`,
    d.RealEstateCode,
    d.Commission,
    trt.NameOfTheRealEstateType AS `Тип недвижимости`
FROM 
    Deals d
JOIN
    Employees e ON d.EmployeeCode = e.PersonCode
JOIN
    Person p ON e.PersonCode = p.Code
JOIN
    RealEstate re ON d.RealEstateCode = re.Code
JOIN
    Person o ON re.OwnerCode = o.Code
JOIN
    TypeOfRealEstate trt ON re.TypeOfRealEstateCode = trt.Code
WHERE d.EmployeeCode = @id";
            string errorMessage;
            if (FieldValidator.ValidateFields(out errorMessage, IDtextBox1))
            {
                DataTable dt = dbHelper.FindRecordById(query, IDtextBox1.Text);
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

        private void SearchBTN2_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
   d.Code,
    d.DealDate,    
    d.EmployeeCode,
    p.FirstName || ' ' || p.LastName AS Сотрудник,
    o.FirstName || ' ' || o.LastName AS `Владелец недвижимости`,
    d.RealEstateCode,
    d.Commission,
    trt.NameOfTheRealEstateType AS `Тип недвижимости`
FROM 
    Deals d
JOIN
    Employees e ON d.EmployeeCode = e.PersonCode
JOIN
    Person p ON e.PersonCode = p.Code
JOIN
    RealEstate re ON d.RealEstateCode = re.Code
JOIN
    Person o ON re.OwnerCode = o.Code
JOIN
    TypeOfRealEstate trt ON re.TypeOfRealEstateCode = trt.Code
WHERE re.OwnerCode = @id";
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
            string query = @"
        SELECT 
   d.Code,
    d.DealDate,    
    d.EmployeeCode,
    p.FirstName || ' ' || p.LastName AS Сотрудник,
    o.FirstName || ' ' || o.LastName AS `Владелец недвижимости`,
    d.RealEstateCode,
    d.Commission,
    trt.NameOfTheRealEstateType AS `Тип недвижимости`
FROM 
    Deals d
JOIN
    Employees e ON d.EmployeeCode = e.PersonCode
JOIN
    Person p ON e.PersonCode = p.Code
JOIN
    RealEstate re ON d.RealEstateCode = re.Code
JOIN
    Person o ON re.OwnerCode = o.Code
JOIN
    TypeOfRealEstate trt ON re.TypeOfRealEstateCode = trt.Code
WHERE d.RealEstateCode = @id";
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
            FieldValidator.ReplaceValuesMaskedTBtoTB(DealDateMaskedTextBox, DealDateTextBox);

            TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel); // Работает если не трогать свойства TextBox

            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, listOfTextBoxes.Skip(1).ToArray()))
            {
                if (FieldValidator.ValidateFields(out errorMessages, DealDateMaskedTextBox))
                {
                    if (!FieldValidator.CheckTextBoxDigitCount(DealDateTextBox, 8))
                    {
                        MessageBox.Show("Поле даты сделки не заполнено полностью!");
                        return;
                    }
                    if (!FieldValidator.ValidateDateTimeField(out errorMessages, DealDateTextBox.Text))
                    {
                        MessageBox.Show(errorMessages);
                        return;
                    }

                    if (!dbHelper.RecordExistsByValueTableColumn(EmployeeCodeTextBox.Text, "Employees", "PersonCode"))
                    {
                        MessageBox.Show("Запись из таблицы Employees с таким Code не существует!");
                        return;
                    }

                    //if (!dbHelper.RecordExistsByValueTableColumn(OwnerCodeTextBox.Text, "Person", "Code"))
                    //{
                    //    MessageBox.Show("Запись из таблицы Person с таким Code не существует!");
                    //    return;
                    //}

                    if (!dbHelper.RecordExistsByValueTableColumn(RealEstateCodeTextBox.Text, "RealEstate", "Code"))
                    {
                        MessageBox.Show("Запись из таблицы Professions с таким Code не существует!");
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

        private void UpdateArrow()
        {
            FieldValidator.ReplaceValuesMaskedTBtoTB(DealDateMaskedTextBox, DealDateTextBox);
            TextBox[] listOfTextBoxes = FieldValidator.FindTextBoxesColumnsPanel(ColumnsPanel);
            
            string errorMessages;
            if (!string.IsNullOrWhiteSpace(CodeTextBox.Text))
            {
                if (DealDateTextBox.Text.Any(char.IsDigit))
                {
                    if (!FieldValidator.CheckTextBoxDigitCount(DealDateTextBox, 8))
                    {
                        MessageBox.Show("Поле даты сделки не заполнено полностью!");
                        return;
                    }

                    if (!FieldValidator.ValidateDateTimeField(out errorMessages, DealDateTextBox.Text))
                    {
                        MessageBox.Show(errorMessages);
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(EmployeeCodeTextBox.Text))
                {
                    if (!dbHelper.RecordExistsByValueTableColumn(EmployeeCodeTextBox.Text, "Employees", "PersonCode"))
                    {
                        MessageBox.Show("Запись из таблицы Employees с таким Code не существует!");
                        return;
                    }
                }

                //if (!string.IsNullOrWhiteSpace(OwnerCodeTextBox.Text))
                //{
                //    if (!dbHelper.RecordExistsByValueTableColumn(OwnerCodeTextBox.Text, "Person", "Code"))
                //    {
                //        MessageBox.Show("Запись из таблицы Person с таким Code не существует!");
                //        return;
                //    }
                //}

                if (!string.IsNullOrWhiteSpace(RealEstateCodeTextBox.Text))
                {
                    if (!dbHelper.RecordExistsByValueTableColumn(RealEstateCodeTextBox.Text, "RealEstate", "Code"))
                    {
                        MessageBox.Show("Запись из таблицы Professions с таким Code не существует!");
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

                        if (textBox.Name == "DealDateTextBox")
                        {
                            // Парсинг строки даты с использованием точного формата
                            DateTime date = DateTime.ParseExact(textBox.Text, "dd.MM.yyyy H:mm:ss", null);
                            // Форматирование даты в нужный формат
                            string formattedDate = date.ToString("yyyy-MM-dd");
                            DealDateMaskedTextBox.Text = formattedDate;
                        }
                    }
                }
            }
        }
    }
}

