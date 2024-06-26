using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Estate_WindowsForms
{
    public static class FieldValidator
    {
        public static bool ValidateFields(out string errorMessages, params TextBox[] textBoxes)
        {
            var errors = new List<string>();
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    errors.Add($"Поле {textBox.Name} не должно быть пустым!");
                }
            }

            errorMessages = string.Join("\n", errors);
            return errors.Count == 0;
        }

        public static bool ValidateFields(out string errorMessages, params MaskedTextBox[] maskedTextBoxes)
        {
            var errors = new List<string>();
            foreach (var maskedTextBox in maskedTextBoxes)
            {
                if (string.IsNullOrWhiteSpace(maskedTextBox.Text))
                {
                    errors.Add($"Поле {maskedTextBox.Name} не должно быть пустым!");
                }
            }

            errorMessages = string.Join("\n", errors);
            return errors.Count == 0;
        }

        public static bool ValidateIntFields(out string errorMessages, params TextBox[] textBoxes)
        {
            var errors = new List<string>();
            foreach (var textBox in textBoxes)
            {
                if (!int.TryParse(textBox.Text, out _))
                {
                    errors.Add($"Поле {textBox.Name} должно содержать целое число!");
                }
            }

            errorMessages = string.Join("\n", errors);
            return errors.Count == 0;
        }

        public static bool ValidateFloatFields(out string errorMessages, params TextBox[] textBoxes)
        {
            var errors = new List<string>();
            foreach (var textBox in textBoxes)
            
            {
                if (!float.TryParse(textBox.Text, out _))
                {
                    errors.Add($"Поле {textBox.Name} должно содержать число!");
                }
            }

            errorMessages = string.Join("\n", errors);
            return errors.Count == 0;
        }

        public static string GetTextBoxName(TextBox textBox)
        {
            return textBox.Name.Replace("TextBox", "");
        }

        public static void ClearTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control.HasChildren)
                {
                    ClearTextBoxes(control); // Рекурсивно очищаем TextBox-ы во вложенных контролах
                }

                if (control is MaskedTextBox maskedTextBox)
                {
                    maskedTextBox.Clear();
                }
                else if (control.HasChildren)
                {
                    ClearTextBoxes(control); // Рекурсивно очищаем TextBox-ы во вложенных контролах
                }
            }
        }


        public static TextBox[] FindTextBoxesColumnsPanel(Panel panel)
        {
            List<TextBox> list = new List<TextBox>();
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    list.Add(textBox);
                }
            }
            list.Reverse();
            return list.ToArray();
        }

        public static MaskedTextBox[] FindMaskedTextBoxesColumnsPanel(Panel panel)
        {
            List<MaskedTextBox> list = new List<MaskedTextBox>();
            foreach (Control control in panel.Controls)
            {
                if (control is MaskedTextBox maskedTextBox)
                {
                    list.Add(maskedTextBox);
                }
            }
            list.Reverse();
            return list.ToArray();
        }

        public static void ReplaceValuesMaskedTBtoTB(MaskedTextBox maskedTextBox, TextBox textBox)
        {
            textBox.Text = maskedTextBox.Text;
        }

        public static void ReplaceValuesTBtoMaskedTB(TextBox textBox, MaskedTextBox maskedTextBox)
        {
            maskedTextBox.Text = textBox.Text;
        }

        public static bool CheckTextBoxLenght(TextBox TextBox, int needLenght)
        {
            return TextBox.TextLength == needLenght;
        }

        public static bool CheckTextBoxDigitCount(TextBox textBox, int requiredDigitCount)
        {
            int digitCount = textBox.Text.Count(char.IsDigit);
            if (digitCount != requiredDigitCount)
            {
                return false;
            }

            return true;
        }


        public static bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateDateTimeFieldWithAge(out string errorMessage, string text)
        {
            if (!DateTime.TryParse(text, out DateTime parsedDate))
            {
                errorMessage = $"Поле даты должно содержать корректную дату и время!";
                return false;
            }

            int age = DateTime.Now.Year - parsedDate.Year;
            if (parsedDate > DateTime.Now.AddYears(-age)) age--; // корректировка на случай, если день рождения ещё не наступил в этом году

            if (age < 18 || age > 100)
            {
                errorMessage = $"Поле даты должно содержать дату, указывающую на возраст от 18 до 100 лет!";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateDateTimeField(out string errorMessage, string text)
        {
            if (!DateTime.TryParse(text, out DateTime parsedDate))
            {
                errorMessage = $"Поле даты должно содержать корректную дату и время!";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }


        public static List<int> ExtractNumbers(string input)
        {
            List<int> numbers = new List<int>();

            // Проходим по строке парами символов
            for (int i = 0; i < input.Length; i += 2)
            {
                if (Char.IsDigit(input[i]) && Char.IsDigit(input[i + 1]))
                {
                    string numberStr = input.Substring(i, 2);
                    numbers.Add(int.Parse(numberStr));
                }
            }

            return numbers;
        }
    }
}
