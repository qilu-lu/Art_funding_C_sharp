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
      [Required(ErrorMessage = "Le champs adress-mail est obligatoire")]
        [Display(Name = "Adresse email")]
        public string adress_mail { get; set; }
       // public entreprise entreprise { get; set; }
       // public artiste artiste { get; set; }
        
        [Required(ErrorMessage = "Le champs mot de passe est obligatoire")]
        [Display(Name = "Mot de passe")]
        public string mot_de_passe { get; set; }
        public bool paiementNExistePas { get; set; }
         public bool docNExistePas { get; set; }

       // bool docNExistePas = utilisateurentreprise.entreprise.document_entreprise == null || utilisateurentreprise.entreprise.document_entreprise.Count() == 0;

        public bool LoggedIn { get; set; }
    }
}
