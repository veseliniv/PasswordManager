using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.API.Models
{
    public class SiteModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Site Name")]
        public string Name { get; set; }
        //public string Password { get; set; }
    }
}
