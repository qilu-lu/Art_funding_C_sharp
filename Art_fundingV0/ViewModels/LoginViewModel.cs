using Art_fundingV0.Models;
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
        public string adress_mail { get; set; }
       // public entreprise entreprise { get; set; }
       // public artiste artiste { get; set; }
        
        [Required(ErrorMessage = "Le champs password est obligatoire")]
        public string mot_de_passe { get; set; }
     
       public bool LoggedIn { get; set; }
    }
}
