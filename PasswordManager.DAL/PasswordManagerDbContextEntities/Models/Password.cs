using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PasswordManager.DAL.PasswordManagerDbContextEntities.Models
{
    [Table("Passwords")]
    public class Password
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        [Column("Encrypted")]
        public string Encrypted { get; set; }

        [OneToOne]
        public Site Site { get; set; } = new Site();
    }
}
