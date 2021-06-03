using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopStore.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "email address:")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }
    }
}