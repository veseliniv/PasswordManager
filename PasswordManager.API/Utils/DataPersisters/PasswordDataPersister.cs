using PasswordManager.API.Models;
using PasswordManager.DAL.PasswordManagerDbContextEntities.DbContextEntities;
using PasswordManager.DAL.PasswordManagerDbContextEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.API.Utils.DataPersisters
{
    public class PasswordDataPersister
    {
        public static void AddPassword(PasswordModel passwordModel)
        {
            PasswordManagerDBEntities entities = new();

            Password newPassword = new() 
            { 
                Pass = passwordModel.Pass, 
                SiteName = passwordModel.SiteName
            };

            entities.Connection.Insert(newPassword);
        }

        public static IEnumerable<PasswordModel> GetPasswords()
        {
            PasswordManagerDBEntities entities = new();

            var siteModels = (from t in entities.Connection.Table<Password>()
                              select new PasswordModel()
                              {
                                  Pass = t.Pass,
                                  SiteName = t.SiteName
                              });

            return siteModels;
        }

        public static string GetRandomGeneratedPassword()
        {
            int length = new Random().Next(1, 100);
            const string alphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_-+=<>.?/|";
            return GetRandomString(length, alphanumericCharacters);
        }

        private static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            RNGCryptoServiceProvider cryptoServiceProvider = new();
            if (length < 0)
            {
                throw new ArgumentException("length must not be negative", "length");
            }
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
            {
                throw new ArgumentException("length is too big", "length");
            }
            if (characterSet == null)
            {
                throw new ArgumentNullException("characterSet");
            }

            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
            {
                throw new ArgumentException("characterSet must not be empty", "characterSet");
            }

            var bytes = new byte[length * 8];
            cryptoServiceProvider.GetBytes(bytes);
            StringBuilder result = new ();
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result.Append(characterArray[value % (uint)characterArray.Length]);
            }
            return result.ToString();
        }
    }
}
