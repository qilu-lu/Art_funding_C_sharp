using Art_fundingV0.Models;
using Art_fundingV0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.Controllers
{
    public class DashboardArtisteController : Controller
    {
        private DalArtiste dalArtiste=new DalArtiste();
        // GET: DashboardArtiste

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

        public ActionResult MonProfil()
        {
            
            ArtisteProfilViewModel artisteProfilViewModel = new ArtisteProfilViewModel();
            artiste artiste = dalArtiste.ObtientUtilisateurA(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name)).artiste;
            ViewBag.prenom = artiste.prenom;
            artisteProfilViewModel.artiste = artiste;

            artisteProfilViewModel.photo = new List<int>();

            foreach (photo Photo in artiste.photos)
            {
                artisteProfilViewModel.photo.Add(Photo.idphoto);
            }

            return View(artisteProfilViewModel);
        }
        
    }
}