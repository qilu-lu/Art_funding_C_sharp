using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art_fundingV0.ViewModels
{
    public class ArtisteProfilViewModel
    {
        public artiste artiste { set; get; }
        public List<int> photo { get; set; }

    }
}