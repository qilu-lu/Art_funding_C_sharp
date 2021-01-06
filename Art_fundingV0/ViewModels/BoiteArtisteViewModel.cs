using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art_fundingV0.ViewModels
{
    public class BoiteArtisteViewModel
    {
        public List<boite_artiste> list{ get; set; }
        public boite_artiste boite_Artiste { get; set; }
        public artiste artiste { get; set; }
        public List<int> photo { get; set; }

    }
}