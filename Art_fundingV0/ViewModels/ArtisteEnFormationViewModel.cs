﻿using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Art_fundingV0.ViewModels
{
    public class ArtisteEnFormationViewModel
    {
        public List<int> photo { get; set; }
        public document_artiste documentArtiste { get; set; }
        public artiste artiste { get; set; }
        public entreprise entreprise { get; set; }
        public List<artiste> TousLesArtistesEnFormation { get; set; }
    }
}