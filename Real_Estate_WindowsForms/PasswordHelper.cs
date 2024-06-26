using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Real_Estate_WindowsForms
{
    internal class PasswordHelper
    {
        /// <summary>
        /// Хэширование строки
        /// </summary>
        /// <param name="password">Строка которую необходимо хэшировать</param>
        /// <returns>Хэшированная строка</returns>
        public static string HashPassword(string password)
        {
            // Создание соли
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Хэширование пароля с использованием соли
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Комбинирование соли и хэша
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Преобразование результата в строку base64
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        /// <summary>
        /// Проверяет сходится ли пароль в обычном виде и хэшиованном
        /// </summary>
        /// <param name="enteredPassword"></param>
        /// <param name="storedHash"></param>
        /// <returns>Возвращает true если значения сходятся</returns>
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Получение хэша и соли из сохраненного хэша
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Хэширование введенного пароля с использованием соли из сохраненного хэша
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Сравнение хэша введенного пароля с сохраненным хэшем
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
