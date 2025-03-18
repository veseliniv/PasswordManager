using System.ComponentModel.DataAnnotations;

namespace PasswordManager.API.Models
{
    public class PasswordModel
    {
        public int ID { get; set; }

        [Required]
        public string Encrypted { get; set; }

        public SiteModel Site { get; set; } = new SiteModel();
    }
}
