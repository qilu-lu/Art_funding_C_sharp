using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art_fundingV0.ViewModels
{
    public class DashboardEntrepriseViewModel
    {
      public  List<artiste> listArtiste { get; set; }
      public  artiste artiste { get; set; }
      public  entreprise entreprise { get; set; }
    }
}