using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Estate_WindowsForms
{
    internal class SQLiteHelper
    {
        private string tableName;

        /// <summary>
        /// Строка подключения, путь к файлу базы данных SQLite
        /// </summary>
        public static string connectingStringFile = @"Data Source=DB/Real_Estate.db";

        public static string IDfieldName = "Code";
        public static SQLiteConnection connection = new SQLiteConnection(connectingStringFile);

        /// <summary>
        /// Объявление класса для работы с БД
        /// </summary>
        /// <param name="tableName"></param>
        public SQLiteHelper(string tableName)
        {
            this.tableName = tableName;
        }

        public SQLiteHelper() { }

        /// <summary>
        /// Обновление подключение
        /// </summary>
        public static void ResetConnection()
        {
            connection = new SQLiteConnection(connectingStringFile);
        }

        /// <summary>
        /// Получение данных DataTable из запроса к базе данных  
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <returns>Возвращает данные в DataTable</returns>
        public DataTable DTExecuteQueryDT(string query)
        {
            ResetConnection();
            using (connection)
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    var dataAdapter = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    dataAdapter.Fill(dt);//System.FormatException: "Строка не распознана как действительное значение DateTime."
                    connection.Close();
                    return dt;
                }
            }
        }

        /// <summary>
        /// Поиск записи по айди
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <param name="id">Искомый айди</param>
        /// <returns>Возвращает данные в DataTable</returns>
        public DataTable FindRecordById(string query, string id)
        {
            ResetConnection();
            using (connection)
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var dataAdapter = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    dataAdapter.Fill(dt);
                    connection.Close();
                    return dt;
                }
            }
        }

        /// <summary>
        /// Поиск записи по значению
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <param name="parameterValue">Искомое значение</param>
        /// <returns>Возвращает данные в DataTable</returns>
        public DataTable FindRecordByValue(string query, string parameterValue)
        {
            ResetConnection();
            using (connection)
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@value", parameterValue);
                    var dataAdapter = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    dataAdapter.Fill(dt);
                    connection.Close();
                    return dt;
                }
            }
        }

        /// <summary>
        /// Проверка существует ли такая запись в текущей таблице
        /// </summary>
        /// <param name="id">Искомый айди</param>
        /// <returns>Возвращает true если такая запись существует</returns>
        public bool RecordExists(string id)
        {
            string query = $"SELECT 1 FROM {tableName} WHERE {IDfieldName} = @id LIMIT 1";
            ResetConnection();
            using (connection)
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var result = cmd.ExecuteScalar();
                    connection.Close();
                    return result != null;
                }
            }
        }

        /// <summary>
        /// Проверка существует ли такая запись в текущей таблице
        /// </summary>
        /// <param name="id">Искомый айди</param>
        /// <param name="fieldName">Наименование столбца</param>
        /// <returns>Возвращает true если такая запись существует</returns>
        public bool RecordExistsByIdField(string id, string fieldName)
        {
            string query = $"SELECT 1 FROM {tableName} WHERE {fieldName} = @id LIMIT 1";
            ResetConnection();
            using (connection)
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var result = cmd.ExecuteScalar();
                    connection.Close();
                    return result != null;
                }
            }
        }

        /// <summary>
        /// Проверка существует ли запись с таким айди в таблице по передаваемому значению, названию таблицы, столбца
        /// </summary>
        /// <param name="value">Искомое значение</param>
        /// <param name="foreignTable">Наименование таблицы</param>
        /// <param name="foreignColumn">Наименование столбца</param>
        /// <returns>Возвращает true если такая запись существует</returns>
        public bool RecordExistsByValueTableColumn(string value, string foreignTable, string foreignColumn)
        {
            string query = $"SELECT 1 FROM {foreignTable} WHERE {foreignColumn} = @value LIMIT 1";
            ResetConnection();
            using (connection)
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@value", value);
                    var result = cmd.ExecuteScalar();
                    connection.Close();
                    return result != null;
                }
            }
        }

        /// <summary>
        /// Обновление записи по айди
        /// </summary>
        /// <param name="id">Айди записи</param>
        /// <param name="fieldName">Наименование столбца</param>
        /// <param name="fieldValue">Новое значение</param>
        /// <returns>Возвращает true если запрос выполнился и поле изменилось</returns>
        public bool UpdateFieldById(string id, string fieldName, object fieldValue)
        {
            if (!RecordExists(id))
            {
                return false;
            }

            string query = $"UPDATE {tableName} SET {fieldName} = @fieldValue WHERE {IDfieldName} = @id";
            ResetConnection();
            using (connection)
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@fieldValue", fieldValue);
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Обновление записи по айди для таблицы с нестандартной колонкой айди 
        /// </summary>
        /// <param name="id">Айди записи</param>
        /// <param name="fieldName">Наименование столбца</param>
        /// <param name="fieldValue">Новое значение</param>
        /// <param name="CodeFieldName">Наименование столбца айди</param>
        /// <returns>Возвращает true если запрос выполнился и поле изменилось</returns>
        public bool UpdateFieldById(string id, string fieldName, object fieldValue, string CodeFieldName)
        {
            if (!RecordExistsByIdField(id, CodeFieldName))
            {
                return false;
            }
            ResetConnection();
            using (connection)
            {
                connection.Open();
                string query = $"UPDATE {tableName} SET ProfessionCode = @fieldValue WHERE {CodeFieldName} = @id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@fieldValue", fieldValue);
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Вставка нового значения
        /// </summary>
        /// <param name="textBoxes">Массив заполненных TextBox с названиями соответствующими наименованиям столбцов</param>
        /// <returns>Если такой записи еще нет и вставка прошла успешно, то возвращается true</returns>
        public bool InsertNewArrow(params TextBox[] textBoxes)
        {
            // Получаем список имен столбцов из переданных TextBox
            List<string> columnsNames = new List<string>();
            foreach (TextBox textBox in textBoxes.Skip(1)) // Пропускаем первый элемент (Code)
            {
                columnsNames.Add(FieldValidator.GetTextBoxName(textBox));
            }

            // Формируем строку для вставки значений в SQL-запрос
            string columns = string.Join(", ", columnsNames);
            string values = string.Join(", ", textBoxes.Skip(1).Select(textBox => $"'{textBox.Text}'")); // Пропускаем первый элемент (Code) и берем текст из остальных TextBox

            // Формируем SQL-запрос для проверки существования записи
            string checkQuery = $"SELECT 1 FROM {tableName} WHERE " +
                string.Join(" AND ", textBoxes.Skip(1).Select(textBox => $"{FieldValidator.GetTextBoxName(textBox)} = '{textBox.Text}'"));

            ResetConnection();
            using (connection)
            {
                connection.Open();

                // Проверка существования записи
                using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                {
                    var result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        connection.Close();
                        return false; // Такая запись уже существует
                    }
                }

                // Если запись не существует, выполняем вставку
                string insertQuery = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                using (var insertCmd = new SQLiteCommand(insertQuery, connection))
                {
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Вставка нового значения для таблицы, вставляя значение во все поля
        /// </summary>
        /// <param name="textBoxes">Массив заполненных TextBox с названиями соответствующими наименованиям столбцов</param>
        /// <returns>Если такой записи еще нет и вставка прошла успешно, то возвращается true</returns>
        public bool InsertNewArrowTableWithNoCode(params TextBox[] textBoxes)
        {
            // Получаем список имен столбцов из переданных TextBox
            List<string> columnsNames = new List<string>();
            foreach (TextBox textBox in textBoxes) // Пропускаем первый элемент (Code)
            {
                columnsNames.Add(FieldValidator.GetTextBoxName(textBox));
            }

            // Формируем строку для вставки значений в SQL-запрос
            string columns = string.Join(", ", columnsNames);
            string values = string.Join(", ", textBoxes.Select(textBox => $"'{textBox.Text}'")); // НЕ Пропускаем первый элемент (Code) и берем текст из всех TextBox

            // Формируем SQL-запрос для проверки существования записи
            string checkQuery = $"SELECT 1 FROM {tableName} WHERE " +
                string.Join(" AND ", textBoxes.Select(textBox => $"{FieldValidator.GetTextBoxName(textBox)} = '{textBox.Text}'"));

            ResetConnection();
            using (connection)
            {
                connection.Open();

                // Проверка существования записи
                using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                {
                    var result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        connection.Close();
                        return false; // Такая запись уже существует
                    }
                }

                // Если запись не существует, выполняем вставку
                string insertQuery = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                using (var insertCmd = new SQLiteCommand(insertQuery, connection))
                {
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }


        /// <summary>
        /// Удаление записи по айди 
        /// </summary>
        /// <param name="id">Искомый айди</param>
        /// <returns>Возвращает true если запрос выполнился и поле удалилось</returns>
        public bool DeleteRecordById(string id)
        {
            if (!RecordExists(id))
            {
                return false;
            }

            string query = $"DELETE FROM {tableName} WHERE {IDfieldName} = @id";
            ResetConnection();
            using (connection)
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Удаление записи по айди для таблицы с нестандартной колонкой айди
        /// </summary>
        /// <param name="id">Искомый айди</param>
        /// <param name="CodeFieldName">Наименование колонки айди</param>
        /// <returns>Возвращает true если запрос выполнился и поле удалилось</returns>
        public bool DeleteRecordById(string id, string CodeFieldName)
        {
            if (!RecordExistsByIdField(id, CodeFieldName))
            {
                return false;
            }

            string query = $"DELETE FROM {tableName} WHERE {CodeFieldName} = @id";
            ResetConnection();
            using (connection)
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Обновление всех заполненных полей записи по айди
        /// </summary>
        /// <param name="id"></param>
        /// <param name="textBoxes"></param>
        /// <returns>Если такой записи еще нет и изменение прошло успешно, то возвращается true</returns>
        public bool UpdateRow(string id, params TextBox[] textBoxes)
        {
            // Проверяем, существует ли запись с указанным айди
            if (!RecordExists(id))
            {
                return false;
            }

            // Формируем список полей для обновления, исключая поле Code
            var fieldsToUpdate = new List<string>();
            foreach (var textBox in textBoxes)
            {
                // Игнорируем поле Code
                if (textBox.Name == $"{IDfieldName}TextBox")
                {
                    continue;
                }

                // Проверяем, что значение поля не пустое
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    // Получаем имя поля и его значение
                    string fieldName = FieldValidator.GetTextBoxName(textBox);
                    string fieldValue = textBox.Text;

                    // Добавляем поле к списку для обновления
                    fieldsToUpdate.Add($"{fieldName} = '{fieldValue}'");
                }
            }

            // Проверяем, что хотя бы одно поле кроме Code было заполнено
            if (fieldsToUpdate.Count == 0)
            {
                return false;
            }


            // Формируем SQL-запрос для проверки существования записи
            string checkQuery = $"SELECT 1 FROM {tableName} WHERE " +
                string.Join(" AND ", textBoxes.Skip(1).Select(textBox => $"{FieldValidator.GetTextBoxName(textBox)} = '{textBox.Text}'"));


            // Формируем запрос на обновление данных
            string fieldsToUpdateString = string.Join(", ", fieldsToUpdate);
            string query = $"UPDATE {tableName} SET {fieldsToUpdateString} WHERE {IDfieldName} = @id";

            ResetConnection();
            using (connection)
            {
                connection.Open();

                using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                {
                    var result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        connection.Close();
                        return false; // Такая запись уже существует
                    }
                }

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="login">Введенный логин</param>
        /// <param name="hashedPassword">Введенный пароль</param>
        /// <returns>Если запрос выполнился успешно, то возвращается true</returns>
        public bool InsertNewUser(string login, string hashedPassword)
        {
            ResetConnection();
            using (connection)
            {
                connection.Open();
                string query = "INSERT INTO Users (Login, Password) VALUES (@login, @password)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
            }
        }

    }

}
