using Art_fundingV0.Models;
using Art_fundingV0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.Controllers
{
    public class DossierFinancementController : Controller
    {
        private DalArtiste dalArtiste;
     
        public DossierFinancementController()
        {
            this.dalArtiste = new DalArtiste();
            // this.dalEntreprise = dalEntreprise;
        }

        // GET: DossierFinancement
        // GET: DossierFinancement
        public ActionResult EtapeDossiersFinancement()
        {
            DossierFinancementViewModel DossierFinancementViewModel = new DossierFinancementViewModel();
             int identreprise = StringUtil.toInt(HttpContext.User.Identity.Name);
          
            List<artiste> TousLesArtistesFinancement = dalArtiste.ObtientArtistesContacte(identreprise);
            DossierFinancementViewModel.TousLesArtistesFinancement = TousLesArtistesFinancement;
            return View(DossierFinancementViewModel);
        }
    }
    }
