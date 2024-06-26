using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Real_Estate_WindowsForms.TablesForms
{
    public partial class RealEstate : Form
    {
        public static string tableName = "RealEstate";
        SQLiteHelper dbHelper = new SQLiteHelper(tableName);

        public RealEstate(bool isAdmin)
        {
            InitializeComponent();
            LoadData();

            if (isAdmin)
            {
                Size = new System.Drawing.Size(new Point(850, 746));
                AdminPanel.Visible = true;
            }
            else
            {
                Size = new System.Drawing.Size(new Point(850, 482));
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
            re.Code,
            re.OwnerCode,
            p.FirstName || ' ' || p.LastName AS Owner,
            re.Address, 
            re.SquareMeters,
            re.TypeOfRealEstateCode,
            tro.NameOfTheRealEstateType AS TypeOfRealEstate, 
            re.Price
        FROM RealEstate re
        JOIN TypeOfRealEstate tro ON re.TypeOfRealEstateCode = tro.Code
        JOIN Person p ON re.OwnerCode = p.Code";
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


        private void UpdatePriceButton_Click(object sender, EventArgs e)
        {
            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, IDtextBox1, PriceUpdateTextBox))
            {
                if (FieldValidator.ValidateIntFields(out errorMessages, IDtextBox1, PriceUpdateTextBox))
                {
                    if (dbHelper.UpdateFieldById(IDtextBox1.Text, "Price", PriceUpdateTextBox.Text))
                    {
                        MessageBox.Show("Цена успешно обновлена.");
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

        private void UpdateAddressButton_Click(object sender, EventArgs e)
        {
            string errorMessages;
            if (FieldValidator.ValidateFields(out errorMessages, IDtextBox3, AddressUpdateTextBox))
            {
                if (FieldValidator.ValidateIntFields(out errorMessages, IDtextBox3))
                {
                    if (dbHelper.UpdateFieldById(IDtextBox3.Text, "Address", AddressUpdateTextBox.Text))
                    {
                        MessageBox.Show("Адрес успешно обновлен.");
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

        private void SearchBTN1_Click(object sender, EventArgs e)
        {
            string query = $@"
        SELECT 
            re.Code,
            re.OwnerCode,
            p.FirstName || ' ' || p.LastName AS Owner,
            re.Address, 
            re.SquareMeters,
            re.TypeOfRealEstateCode,
            tro.NameOfTheRealEstateType AS TypeOfRealEstate, 
            re.Price
        FROM RealEstate re
        JOIN TypeOfRealEstate tro ON re.TypeOfRealEstateCode = tro.Code
        JOIN Person p ON re.OwnerCode = p.Code
        WHERE re.Code = @id";
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
        private void SearchBTN2_Click(object sender, EventArgs e)
        {
            string query = $@"
        SELECT 
            re.Code,
            re.OwnerCode,
            p.FirstName || ' ' || p.LastName AS Owner,
            re.Address, 
            re.SquareMeters,
            re.TypeOfRealEstateCode,
            tro.NameOfTheRealEstateType AS TypeOfRealEstate, 
            re.Price
        FROM RealEstate re
        JOIN TypeOfRealEstate tro ON re.TypeOfRealEstateCode = tro.Code
        JOIN Person p ON re.OwnerCode = p.Code
        WHERE re.OwnerCode = @id";
            string errorMessage;
            if (FieldValidator.ValidateFields(out errorMessage, IDtextBox4))
            {
                    DataTable dt = dbHelper.FindRecordById(query, IDtextBox4.Text);
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
            re.Code,
            re.OwnerCode,
            p.FirstName || ' ' || p.LastName AS Owner,
            re.Address, 
            re.SquareMeters,
            re.TypeOfRealEstateCode,
            tro.NameOfTheRealEstateType AS TypeOfRealEstate, 
            re.Price
        FROM RealEstate re
        JOIN TypeOfRealEstate tro ON re.TypeOfRealEstateCode = tro.Code
        JOIN Person p ON re.OwnerCode = p.Code
        WHERE re.TypeOfRealEstateCode = @id";
            string errorMessage;
            if (FieldValidator.ValidateFields(out errorMessage, IDtextBox5))
            {
                DataTable dt = dbHelper.FindRecordById(query, IDtextBox5.Text);
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
            if (FieldValidator.ValidateFields(out errorMessages, listOfTextBoxes.Skip(1).ToArray()))
            {
                if (FieldValidator.ValidateIntFields(out errorMessages, OwnerCodeTextBox, TypeOfRealEstateCodeTextBox))
                {
                    if (FieldValidator.ValidateFloatFields(out errorMessages, SquareMetersTextBox, PriceTextBox))
                    {
                        if (!dbHelper.RecordExistsByValueTableColumn(OwnerCodeTextBox.Text, "Person", "Code"))
                        {
                            MessageBox.Show("Запись из таблицы Person с таким Code не существует!");
                            return;
                        }

                        if (!dbHelper.RecordExistsByValueTableColumn(TypeOfRealEstateCodeTextBox.Text, "TypeOfRealEstate", "Code"))
                        {
                            MessageBox.Show("Запись из таблицы TypeOfRealEstate с таким Code не существует!");
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
                if (!string.IsNullOrWhiteSpace(OwnerCodeTextBox.Text))
                {
                    if (!dbHelper.RecordExistsByValueTableColumn(OwnerCodeTextBox.Text, "Person", "Code"))
                    {
                        MessageBox.Show("Запись из таблицы Person с таким Code не существует!");
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(TypeOfRealEstateCodeTextBox.Text))
                {
                    if (!dbHelper.RecordExistsByValueTableColumn(TypeOfRealEstateCodeTextBox.Text, "TypeOfRealEstate", "Code"))
                    {
                        MessageBox.Show("Запись из таблицы TypeOfRealEstate с таким Code не существует!");
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
            if (dbHelper.RecordExistsByValueTableColumn(Code, "Deals", "RealEstateCode"))
            {
                MessageBox.Show("Запись с этой недвижимостью есть в таблице Deals.\nУдаление невозможно!");
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

        private void AddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
