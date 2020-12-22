using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Art_fundingV0.ViewModels

{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Le champs username est obligatoire")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Le champs password est obligatoire")]
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
    }
}
