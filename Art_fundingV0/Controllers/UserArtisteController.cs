//using Art_fundingV0.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Art_fundingV0.Controllers
//{
//    public class UserArtisteController : Controller
//    {
//        // GET: UserArtiste
//        public ActionResult Index()
//        {
//            LoginViewModel viewModelentre = new LoginViewModel { LoggedIn = HttpContext.User.Identity.IsAuthenticated };
//            if (HttpContext.User.Identity.IsAuthenticated)
//            {
//                string adresse_email = viewModelentre.adresse_email;
//                string mot_de_passe = viewModelentre.mot_de_passe;
//                entreprise = new entreprise() { mail = mail, mot_de_passe = mot_de_passe };
//                entreprise = dal.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name);
//            }
//            return View(viewModelentre);
//        }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Art_fundingV0.Models;
using Art_fundingV0.ViewModels;
namespace Art_fundingV0.Controllers
{
    public class UserArtisteController : Controller
    {

        private IDal dal;
        public UserArtisteController() : this(new Dal())
        {
        }
        private UserArtisteController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        [HttpGet]
        public ActionResult Index()
        {
            LoginViewModel viewModelart = new LoginViewModel { LoggedIn = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string mail = viewModelart.adresse_email;
                string mot_de_passe = viewModelart.mot_de_passe;
                artiste artiste = new artiste() { mail = mail, mot_de_passe = mot_de_passe };
                artiste = dal.ObtientTousLesArtistes(HttpContext.User.Identity.Name);
            }
            return View(viewModelart);
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                utilisateurartiste artiste = dal.AuthentifierArtiste(viewModel.adresse_email, viewModel.mot_de_passe);
                if (artiste != null)
                {
                    FormsAuthentication.SetAuthCookie(artiste.idartiste.ToString(), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }
                ModelState.AddModelError("utilisateurArtiste.mailUA", "wrong login");
                //view??? error
            }
            return View(viewModel);
        }
        public ActionResult CreerCompte()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreerCompte(ArtisteViewModel avm)
        {
            if (ModelState.IsValid)
            {
                //verifie si le compte existe deja
                var isArtistemailAlreadyExists = dal.ObtientTousLesArtistes().Any(u => u.mail.ToLower() == avm.artiste.mail.ToLower());
                if (isArtistemailAlreadyExists)
                {
                    ModelState.AddModelError("Username", "This username already exists");
                    return View(avm);
                }
                int id = dal.AjouterUserArtiste(avm.artiste.mail, avm.artiste.mot_de_passe);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);
                return Redirect("/");
            }
            return View(avm);
        }
    }
}
//    }
//}


