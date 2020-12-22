using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Art_fundingV0.Models
{
    public class BddContext:DbContext
    {
        public DbSet<artiste> Artistes { get; set; }
        public DbSet<entreprise> Entreprises { get; set; }
        public DbSet<utilisateurentreprise> utilisateurentreprises { get; set; }
        public DbSet<utilisateurartiste> utilisateurartistes { get; set; }





    }
}