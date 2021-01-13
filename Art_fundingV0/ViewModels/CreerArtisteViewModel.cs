using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.ViewModels
{
    public class CreerArtisteViewModel
    {
        [Display(Name = "Je choisis mon futur établissement de formation ")]
        public IEnumerable<int> SelectedEcoleIds { get; set; }

        public IEnumerable<SelectListItem> EcoleList { get; set; }
        public utilisateurartiste utilisateurartiste { get; set; }

        [Display(Name = "Je choisis la catégorie")]
        public IEnumerable<int> SelectedCategorieIds { get; set; }

        public IEnumerable<SelectListItem> CategorieList { get; set; }
    }
}