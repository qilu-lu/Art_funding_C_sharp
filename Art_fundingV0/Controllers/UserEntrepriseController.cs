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
    public class userEntrepriseController : Controller
    {
        private IDal dal;
        public userEntrepriseController() : this(new Dal())
        {
        }
        private userEntrepriseController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        [HttpGet]
        public ActionResult Index()
        {
            LoginViewModel viewModelentre = new LoginViewModel { LoggedIn = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string adresse_email = viewModelentre.adresse_email;
                string mot_de_passe = viewModelentre.mot_de_passe;
                entreprise entreprise = new entreprise() { adresse_email = adresse_email, mot_de_passe = mot_de_passe };
                entreprise = dal.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name);
            }
            return View(viewModelentre);
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
               utilisateurentreprise entreprise = dal.AuthentifierEntreprise(viewModel.adresse_email, viewModel.mot_de_passe);
                if (entreprise != null)
                {
                    FormsAuthentication.SetAuthCookie(entreprise.identreprise.ToString(), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }
                ModelState.AddModelError("utilisateurentreprise.adresse_emailUE", "wrong login");
                //view??? error
            }
            return View(viewModel);
        }
        public ActionResult CreerCompte()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreerCompte(EntrepriseViewModel evm)
        {
            if (ModelState.IsValid)
            {
                //verifie si le compte existe deja
                var isEntreprisemailAlreadyExists = dal.ObtientToutesLesEntreprises().Any(u => u.adresse_email.ToLower() == evm.entreprise.adresse_email.ToLower());
                if (isEntreprisemailAlreadyExists)
                {
                    ModelState.AddModelError("Username", "This username already exists");
                    return View(evm);
                }
                int id = dal.AjouterUserEntreprise(evm.entreprise.adresse_email, evm.entreprise.mot_de_passe);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);
                return Redirect("/");
            }
            return View(evm);
        }
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}