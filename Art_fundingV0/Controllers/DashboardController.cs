using Art_fundingV0.Models;
using Art_fundingV0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Art_fundingV0.Controllers
{
    public class DashboardController : Controller
    {
        private IDalArtiste dalArtiste;
        private IDalEntreprise dalEntreprise;
        private art_fundingEntities context = new art_fundingEntities();
        public DashboardController() : this(new DalArtiste(), new DalEntreprise())
        {
        }
        private DashboardController(IDalArtiste dalIoc, IDalEntreprise dalEnt)
        {
            dalArtiste = dalIoc;
            dalEntreprise = dalEnt;
        }
        // GET: Dashboard
        public ActionResult AccueilDashboard()
        {
            utilisateurentreprise utilisateurentreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name));
            ViewBag.prenom = utilisateurentreprise.entreprise.prenom_de_l_ayant_droit;
            return View();
        }
        public ActionResult BoiteArtiste()
        {
            return View();
        }
        // Les vues endessous ne sont pas encore créer
        public ActionResult ArtisteContactes()
        {
            DashboardEntrepriseViewModel dashboardEntrepriseViewModel = new DashboardEntrepriseViewModel();
            entreprise entreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name)).entreprise;
            ViewBag.prenom = entreprise.prenom_de_l_ayant_droit;
            int identreprise = entreprise.identreprise;
            
            dashboardEntrepriseViewModel.listArtiste = dalArtiste.ObtientArtistesContacte(identreprise);
            foreach (artiste a in dashboardEntrepriseViewModel.listArtiste)
            {
                if (a.description.Count() > 100)
                {
                    a.description = a.description.Substring(0, 97) + "...";
                }
            }
            return View(dashboardEntrepriseViewModel);
        }
        public ActionResult DossierDeFinancement()
        {
            return View();
        }
        public ActionResult EnFormation()
        {
            return View();
        }
        public ActionResult Messagerie()
        {
            return View();
        }
    }
}