using PasswordManager.API.Models;
using PasswordManager.DAL.PasswordManagerDbContextEntities.DbContextEntities;
using PasswordManager.DAL.PasswordManagerDbContextEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.API.Utils.DataPersisters
{
    public class PasswordDataPersister
    {
        public static void AddPassword(string pass, string siteName)
        {
            PasswordManagerDBEntities entities = new();

            Password newPassword = new() 
            { 
                Pass = pass, 
                SiteName =  siteName
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
    }
}
