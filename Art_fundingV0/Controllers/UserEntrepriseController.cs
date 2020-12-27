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
                utilisateurentreprise utilisateurentreprise = dal.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name);

                viewModelentre.adress_mail = utilisateurentreprise.adresse_mailUE;
               // viewModelentre.entreprise = utilisateurentreprise.entreprise;
                /*string adresse_email = viewModelentre.adress_mail;
                string mot_de_passe = viewModelentre.mot_de_passe;
                
                 entreprise = new entreprise() { adresse_email = adresse_email, mot_de_passe = mot_de_passe };
                
               //viewModelentre.entreprise = entreprise;*/
            }
            return View(viewModelentre);
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
               utilisateurentreprise entreprise = dal.AuthentifierEntreprise(viewModel.adress_mail, viewModel.mot_de_passe);
                if (entreprise != null)
                {
                    FormsAuthentication.SetAuthCookie(entreprise.idUtilisateurEntreprise.ToString(), false);
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

        public ActionResult CreerCompte(utilisateurentreprise utilisateur)
        {
            if (ModelState.IsValid)
            {
                //verifie si le compte existe deja
                var EntreprisemailAlreadyExists = dal.getUtilisateurEntrepriseParEmail(utilisateur.adresse_mailUE.ToLower());
                if (EntreprisemailAlreadyExists != null)
                {
                    ModelState.AddModelError("Username", "This username already exists");
                    return View(utilisateur);
                }
                int id = dal.AjouterUserEntreprise(utilisateur.adresse_mailUE, utilisateur.mot_de_passeUE, utilisateur.entreprise);
             //   dal.ajouterEntreprise(entreprise);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);
                //return Redirect("/");
               return  RedirectToAction("Index");
            }
            return View(utilisateur);
        }







        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}