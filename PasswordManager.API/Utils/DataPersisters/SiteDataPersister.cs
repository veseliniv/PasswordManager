using PasswordManager.API.Models;
using PasswordManager.DAL.PasswordManagerDbContextEntities.DbContextEntities;
using PasswordManager.DAL.PasswordManagerDbContextEntities.Models;

namespace PasswordManager.API.Utils.DataPersisters
{
    public class SiteDataPersister
    {
        public static void AddSite()
        {
            PasswordManagerDBEntities entities = new();

            Site newSite = new() { Name = "Test Site5" };

            entities.Connection.Insert(newSite);
        }

        public static IEnumerable<SiteModel> GetSites()
        {
            PasswordManagerDBEntities entities = new();

            var siteModels = (from t in entities.Connection.Table<Site>()
                              select new SiteModel()
                              {
                                  ID= t.ID,
                                  Name = t.Name
                              });

            return siteModels;
        }
    }
}
