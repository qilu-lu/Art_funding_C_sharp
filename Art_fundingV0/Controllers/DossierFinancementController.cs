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
        private IDalArtiste dalArtiste;
        private IDalEntreprise dalEntreprise;
        public DossierFinancementController()
        {
            this.dalArtiste = new DalArtiste();
             this.dalEntreprise = new DalEntreprise();
        }

        // GET: DossierFinancement
        // GET: DossierFinancement
        public ActionResult EtapeDossiersFinancement()
        {
            DossierFinancementViewModel DossierFinancementViewModel = new DossierFinancementViewModel();


            entreprise entreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name)).entreprise;
            ViewBag.prenom = entreprise.prenom_de_l_ayant_droit;
            int identreprise = entreprise.identreprise;
          
            List<artiste> TousLesArtistesFinancement = dalArtiste.ObtientArtistesContacte(identreprise);
            DossierFinancementViewModel.TousLesArtistesFinancement = TousLesArtistesFinancement;
            return View(DossierFinancementViewModel);
        }

        public ActionResult ValiderDossierFinancement()
        {
            entreprise entreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name)).entreprise;
            ViewBag.prenom = entreprise.prenom_de_l_ayant_droit;
            return View();
        }

        [HttpPost]
        public ActionResult ValiderDossierFinancement(int? id)
        {
           return RedirectToAction("TelechargerDossierFinancement");
        }

        public ActionResult TelechargerDossierFinancement()
        {
            return View();
        }
    }
}
