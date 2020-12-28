using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.ViewModels
{
    public class CreerEntrepriseViewModel
    {
     
        public IEnumerable<int> SelectedMoisIds { get; set; }

        public IEnumerable<SelectListItem> MoisList { get; set; }

        public IEnumerable<int> SelectedAnneeIds { get; set; }

        public IEnumerable<SelectListItem> AnneeList { get; set; }


        public utilisateurentreprise utilisateurentreprise { get; set; }
    }
}