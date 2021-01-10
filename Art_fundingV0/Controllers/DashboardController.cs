﻿using Art_fundingV0.Models;
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
            entreprise entreprise = dalEntreprise.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name).entreprise;
            int identreprise = entreprise.identreprise;
            
            dashboardEntrepriseViewModel.listArtiste = dalArtiste.ObtientArtistesContacte(identreprise);
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