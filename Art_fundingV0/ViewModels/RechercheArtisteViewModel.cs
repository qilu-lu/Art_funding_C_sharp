﻿using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art_fundingV0.ViewModels
{
    public class RechercheArtisteViewModel
    {
       public List<artiste> listArtiste { get; set; }
        public artiste artiste { get; set; }
    }
}