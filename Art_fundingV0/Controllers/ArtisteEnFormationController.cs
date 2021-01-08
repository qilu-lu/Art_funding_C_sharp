using Art_fundingV0.Models;
using Art_fundingV0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Art_fundingV0.Controllers
{
    public class ArtisteEnFormationController : Controller
    {
        private IDalArtiste dalArtiste;
        private IDalEntreprise dalEntreprise;
        public ArtisteEnFormationController()
        {
            this.dalArtiste = new DalArtiste();
            this.dalEntreprise = new DalEntreprise();
        }
        // GET: ArtisteEnFormation
        public ActionResult ArtisteEnFormation()
        {
            ArtisteEnFormationViewModel ArtisteEnFormationViewModel = new ArtisteEnFormationViewModel();
            entreprise entreprise = dalEntreprise.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name).entreprise;
            int identreprise = entreprise.identreprise;
            List<artiste> TousLesArtistesEnFormation = dalArtiste.ObtientArtistesEnFormation(identreprise);
            ArtisteEnFormationViewModel.TousLesArtistesEnFormation = TousLesArtistesEnFormation;
            return View(ArtisteEnFormationViewModel);
        }
        public void getPhoto(int idPhoto)
        {
            //Verfiier que c'est bien une entreprise qui est connectée
            byte[] fileContents = dalArtiste.ObtientPhoto(idPhoto);
            Response.Clear();
            Response.AddHeader("Content-Length", fileContents.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=FILENAME");
            Response.OutputStream.Write(fileContents, 0, fileContents.Length);
            Response.Flush();
            Response.End();
            // return null;
        }
    }
}