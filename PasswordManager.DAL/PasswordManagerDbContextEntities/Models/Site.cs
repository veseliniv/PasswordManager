using SQLite;

namespace PasswordManager.DAL.PasswordManagerDbContextEntities.Models
{
    [Table("Sites")]
    public class Site
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}
