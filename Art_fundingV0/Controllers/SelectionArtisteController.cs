using Art_fundingV0.Models;
using Art_fundingV0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.Controllers
{
    public class SelectionArtisteController : Controller
    {
        
            private IDalArtiste dalArtiste;
        private IDalEntreprise dalEntreprise=new DalEntreprise();
            public SelectionArtisteController() : this(new DalArtiste())
            {
            }
            private SelectionArtisteController(IDalArtiste dalIoc)
            {
                dalArtiste = dalIoc;
            }
            // GET: SelectionArtiste
            public ActionResult SelectionArtiste()
            {
                List<artiste> listArtiste = new List<artiste>();
                listArtiste = dalArtiste.ObtientTousLesArtistes();

                return View(listArtiste);
            }

            public ActionResult RechercheArtiste()
            {
            entreprise entreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name)).entreprise;
            ViewBag.nom_entreprise = entreprise.prenom_de_l_ayant_droit;
            RechercheArtisteViewModel rechercheArtisteViewModel = new RechercheArtisteViewModel();
            List<artiste> listArtiste = new List<artiste>();
               listArtiste = dalArtiste.ObtientTousLesArtistes();
            rechercheArtisteViewModel.listArtiste = listArtiste;
            foreach (artiste a in rechercheArtisteViewModel.listArtiste)
            {
                if (a.description.Count() >100 )
                {
                    a.description = a.description.Substring(0, 97) + "...";
                }
            }
            return View(rechercheArtisteViewModel);
            }

        [HttpPost]
        public ActionResult RechercheArtiste(string searchString)
        {
            entreprise entreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name)).entreprise;
            ViewBag.nom_entreprise = entreprise.prenom_de_l_ayant_droit;
            RechercheArtisteViewModel rechercheArtisteViewModel = new RechercheArtisteViewModel();
            
            List<artiste> list = dalArtiste.RechercheArtistes(searchString);
            rechercheArtisteViewModel.listArtiste = list;
            foreach (artiste a in rechercheArtisteViewModel.listArtiste)
            {
                if (a.description.Count() > 100)
                {
                    a.description = a.description.Substring(0, 97) + "...";
                }
            }

            return View(rechercheArtisteViewModel);
        }

    }
}
