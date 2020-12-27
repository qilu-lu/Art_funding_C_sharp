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
                string mail = viewModelart.adress_mail;
                string mot_de_passe = viewModelart.mot_de_passe;
                utilisateurartiste utilisateurartiste = new utilisateurartiste() { mailUA = mail, mot_de_passe = mot_de_passe };
                utilisateurartiste = dal.ObtientTousLesArtistes(HttpContext.User.Identity.Name);
                
              //  dal.ObtientTousLesEcoles();
            }
            return View(viewModelart);
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                utilisateurartiste artiste = dal.AuthentifierArtiste(viewModel.adress_mail, viewModel.mot_de_passe);
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
            CreerArtisteViewModel CreerArtisteViewModel = new CreerArtisteViewModel();
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (ecole ecole in dal.ObtientTousLesEcoles())
            {
                list.Add(new SelectListItem { Text = ecole.nom, Value = ecole.idecole + "", Selected = false});
            }
            CreerArtisteViewModel.SelectedEcoleIds = new List<int>();

                CreerArtisteViewModel.EcoleList = list; 
            return View(CreerArtisteViewModel);
        }
        [HttpPost]
        public ActionResult CreerCompte(CreerArtisteViewModel creerArtiste)
        {
            if (ModelState.IsValid)
            {
                //verifie si le compte existe deja
                //                var isArtistemailAlreadyExists = dal.obtenirtouslesartistes().FirstOrDefault(u => u.mail.ToLower() == utilisateur.mailUA.ToLower());
                utilisateurartiste utilisateur = creerArtiste.utilisateurartiste;

                var isArtistemailAlreadyExists = dal.getUtilisateurArtisteParEmail(utilisateur.mailUA.ToLower());
                if (isArtistemailAlreadyExists != null)
                {
                    ModelState.AddModelError("Username", "This username already exists");
                    return View(utilisateur);
                }
                int id = dal.AjouterUserArtiste(utilisateur.mailUA, utilisateur.mot_de_passe, creerArtiste);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);
                return Redirect("/");
            }
            return View();
        }
    }
}
//    }
//}


