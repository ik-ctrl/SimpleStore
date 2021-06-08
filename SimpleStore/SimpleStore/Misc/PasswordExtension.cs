using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace SimpleStore.Misc
{
    internal static class PasswordExtension
    {
        /// <summary>
        /// Получить хэщ засоленного пароля
        /// </summary>
        /// <param name="password">пароль</param>
        /// <param name="salt">соль</param>
        /// <returns>Возвращает хэш засоленного пароля в нижнем регистре </returns>
        internal static string GetHashFromSalPassword(string password, string salt)
        {
            var checkArguments = string.IsNullOrEmpty(password) || string.IsNullOrEmpty(salt);
            Contract.Requires<ArgumentNullException>(!checkArguments, "Password or salt is null");
            var saltPassword = password + salt;
            string resultHash;
            using (var shaManager = new SHA256Managed())
            {
                var bytes = Encoding.UTF8.GetBytes(saltPassword);
                var hash = shaManager.ComputeHash(bytes);
                resultHash = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
            return resultHash;
        }
    }
}
