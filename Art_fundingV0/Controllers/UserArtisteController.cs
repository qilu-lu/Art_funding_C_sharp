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

        private IDalArtiste dalArtiste;
        private IDalEcole dalEcole;
        public UserArtisteController() : this(new DalArtiste(), new DalEcole())
        {
        }
        private UserArtisteController(IDalArtiste dalIoc, IDalEcole dalecolen)
        {
            dalArtiste = dalIoc;
            dalEcole = dalecolen;
        }
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel viewModelart = new LoginViewModel { LoggedIn = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                
                utilisateurartiste utilisateurartiste = dalArtiste.ObtientTousLesArtistes(HttpContext.User.Identity.Name);
                viewModelart.adress_mail = utilisateurartiste.mailUA;
                
            }
            return View(viewModelart);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                utilisateurartiste artiste = dalArtiste.AuthentifierArtiste(viewModel.adress_mail, viewModel.mot_de_passe);
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
            List<SelectListItem> list2 = new List<SelectListItem>();

            foreach (ecole ecole in dalEcole.ObtientTousLesEcoles())
            {
                list.Add(new SelectListItem { Text = ecole.nom, Value = ecole.idecole + "", Selected = false });
            }
            CreerArtisteViewModel.SelectedEcoleIds = new List<int>();
            CreerArtisteViewModel.EcoleList = list;
            foreach (categorie categorie in dalEcole.ObtientTousLesCategories())
            {
                list2.Add(new SelectListItem { Text = categorie.nom, Value = categorie.id_categorie + "", Selected = false });
            }
            CreerArtisteViewModel.SelectedCategorieIds = new List<int>();

            CreerArtisteViewModel.CategorieList = list2;
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

                var isArtistemailAlreadyExists = dalArtiste.getUtilisateurArtisteParEmail(utilisateur.mailUA.ToLower());
                if (isArtistemailAlreadyExists != null)
                {
                    ModelState.AddModelError("Username", "This username already exists");
                    return View(utilisateur);
                }
                int id = dalArtiste.AjouterUserArtiste(utilisateur.mailUA, utilisateur.mot_de_passe, creerArtiste);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);
                
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}



