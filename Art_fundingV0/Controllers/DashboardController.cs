using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult AccueilDashboard()
        {
            return View();
        }

        public ActionResult BoiteArtiste()
        {
            return View();
        }

        // Les vues endessous ne sont pas encore créer

        public ActionResult ArtisteContactés()
        {
            return View();
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