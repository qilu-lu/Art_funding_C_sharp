using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.ViewModels
{
    public class CreerEntrepriseViewModel
    {
        [Display(Name = "Mois")]
        public IEnumerable<int> SelectedMoisIds { get; set; }

        public IEnumerable<SelectListItem> MoisList { get; set; }
        [Display(Name = "Année")]
        public IEnumerable<int> SelectedAnneeIds { get; set; }

        public IEnumerable<SelectListItem> AnneeList { get; set; }


        public utilisateurentreprise utilisateurentreprise { get; set; }
    }
}