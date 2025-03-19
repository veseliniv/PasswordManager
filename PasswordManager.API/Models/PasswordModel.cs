﻿using System.ComponentModel.DataAnnotations;

namespace PasswordManager.API.Models
{
    public class PasswordModel
    {
        public int ID { get; set; }

        [Required]
        public string Pass { get; set; }

        public string SiteName { get; set; }
    }
}
