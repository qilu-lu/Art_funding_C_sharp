﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art_fundingV0.Models;

namespace Art_fundingV0.ViewModels
{
    public class ArtisteViewModel
    {
        public artiste artiste { get; set; }
        public bool Authentifie { get; set; }
    }
}