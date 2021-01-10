using Art_fundingV0.Models;
using Art_fundingV0.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.Controllers
{
    public class BoiteArtisteController : Controller
    {

        private DalArtiste dalArtiste;
        private DalEntreprise dalEntreprise;
        private art_fundingEntities context = new art_fundingEntities();
        public BoiteArtisteController()
        {
            this.dalArtiste = new DalArtiste();
            this.dalEntreprise = new DalEntreprise();
        }

        // GET: BoiteArtiste
        public ActionResult Index()
        {
            BoiteArtisteViewModel boiteArtisteViewModel = new BoiteArtisteViewModel();
            entreprise entreprise = dalEntreprise.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name).entreprise;
            List<boite_artiste> liste = dalArtiste.ObtientTousLesBoitesparentreprise(entreprise.identreprise);
            boiteArtisteViewModel.list = liste;


            return View(boiteArtisteViewModel);
        }

       

      public ActionResult AjouterArtiste(int? idartiste)
      {
            entreprise entreprise = dalEntreprise.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name).entreprise;
            foreach (artiste artiste in dalArtiste.ObtientArtistesdansBoiteArtiste(entreprise.identreprise))
            {
                if (artiste.idartiste == idartiste)
                {
                    return RedirectToAction("Portfoliu", new { idartiste = idartiste, msg = "Attention, vous avez déjà ajouté cet artiste" });
                }
            }
                dalArtiste.AjouterBoiteArtiste(entreprise.identreprise, idartiste);
            
            return RedirectToAction("Portfoliu", new { idartiste = idartiste, msg = "Vous venez d'ajouter cet artiste" });
        }




        public ActionResult Supprimer(int? idArtiste)
        {
            entreprise entreprise = dalEntreprise.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name).entreprise;
            dalArtiste.SupprimerBoiteArtiste(entreprise.identreprise, idArtiste);
            return RedirectToAction("Index");
        }

        public void getPhoto(int idPhoto)
        {

            //Verfiier que c'est bien une entreprise qui est connectée
            byte[] fileContents = dalArtiste.ObtientPhoto(idPhoto);
            Response.Clear();
            Response.AddHeader("Content-Length", fileContents.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=image.png");
            Response.OutputStream.Write(fileContents, 0, fileContents.Length);
            Response.Flush();
            Response.End();
            // return null;
        }


        public ActionResult Portfoliu(int? idArtiste, String msg)
        {


            artiste artiste = dalArtiste.ObtientTousLesArtistes(idArtiste.Value);

            BoiteArtisteViewModel boiteArtisteViewModel = new BoiteArtisteViewModel();
            boiteArtisteViewModel.msg = msg;
            boiteArtisteViewModel.artiste = artiste;

            boiteArtisteViewModel.photo = new List<int>();

            foreach (photo Photo in artiste.photos)
            {
                boiteArtisteViewModel.photo.Add(Photo.idphoto);
            }

            return View(boiteArtisteViewModel);
        }




       












    }
}