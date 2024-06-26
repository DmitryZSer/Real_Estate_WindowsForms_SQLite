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
        /// <summary>
        /// Проверка заполненности передаваемых TextBox
        /// </summary>
        /// <param name="errorMessages">Сообщение об ошибке</param>
        /// <param name="textBoxes">Массив TextBox</param>
        /// <returns>В случае если один или более незаполненны возвращается false и текст ошибки</returns>
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

        /// <summary>
        /// Проверка заполненности передаваемых MaskedTextBox
        /// </summary>
        /// <param name="errorMessages">Сообщение об ошибке</param>
        /// <param name="maskedTextBoxes">Массив MaskedTextBox</param>
        /// <returns>В случае если один или более незаполненны возвращается false и текст ошибки</returns>
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

        /// <summary>
        /// Проверка заполненности полей с целочисленными значениями
        /// </summary>
        /// <param name="errorMessages">Сообщение об ошибке</param>
        /// <param name="textBoxes">Массив TextBox</param>
        /// <returns>В случае если один или более не соответствуют возвращается false и текст ошибки</returns>
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

        /// <summary>
        /// Проверка заполненности полей с плавающей запятой
        /// </summary>
        /// <param name="errorMessages">Сообщение об ошибке</param>
        /// <param name="textBoxes">Массив TextBox</param>
        /// <returns>В случае если один или более не соответствуют возвращается false и текст ошибки</returns>
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

        /// <summary>
        /// Получить наименование столбца из TextBox
        /// </summary>
        /// <param name="textBox">TextBox имя столбца из которого необходимо получить</param>
        /// <returns>Текстовое значение наименования столбца</returns>
        public static string GetTextBoxName(TextBox textBox)
        {
            return textBox.Name.Replace("TextBox", "");
        }

        /// <summary>
        /// Очистка всех полей на форме
        /// </summary>
        /// <param name="parent">Форма, в которой нужно очистить поля</param>
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

        /// <summary>
        /// Поиск всех TextBox на нужной панели
        /// </summary>
        /// <param name="panel">Панель из формы</param>
        /// <returns>Список всех найденных TextBox</returns>
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

        /// <summary>
        /// Поиск всех MaskedTextBox на нужной панели
        /// </summary>
        /// <param name="panel">Панель из формы</param>
        /// <returns>Список всех найденных MaskedTextBox</returns>
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

        /// <summary>
        /// Передача значения из MaskedTextBox к TextBox
        /// </summary>
        /// <param name="maskedTextBox">Откуда передается</param>
        /// <param name="textBox">Куда передается</param>
        public static void ReplaceValuesMaskedTBtoTB(MaskedTextBox maskedTextBox, TextBox textBox)
        {
            textBox.Text = maskedTextBox.Text;
        }

        /// <summary>
        /// Передача значения из TextBox к MaskedTextBox
        /// </summary>
        /// <param name="textBox">Откуда передается</param>
        /// <param name="maskedTextBox">Куда передается</param>
        public static void ReplaceValuesTBtoMaskedTB(TextBox textBox, MaskedTextBox maskedTextBox)
        {
            maskedTextBox.Text = textBox.Text;
        }

        /// <summary>
        /// Проверяет введен ли правильный формат почты
        /// </summary>
        /// <param name="email">Значение которое нужно проверить</param>
        /// <returns>Возвращает true — если формат почты введен правильно, false — если нет</returns>
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

        /// <summary>
        /// Проверяет введен ли правильный формат даты и соответствует ли возраст от 18 до 100 лет 
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <param name="text">Текст проверяемой даты</param>
        /// <returns>Возвращает true — если формат даты введен правильно, false — если нет</returns>
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

        /// <summary>
        /// Проверяет введен ли правильный формат даты
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <param name="text">Текст проверяемой даты</param>
        /// <returns>Возвращает true — если формат даты введен правильно, false — если нет</returns>
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
    }
}
