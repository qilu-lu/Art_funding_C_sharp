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
        private DalEntreprise dalEntreprise;
        public userEntrepriseController() : this(new DalEntreprise())
        {
        }
        private userEntrepriseController(DalEntreprise dalIoc)
        {
            dalEntreprise = dalIoc;
        }

        [HttpGet]
        public ActionResult Login()
        {
            //LoginViewModel viewModelentre = new LoginViewModel { LoggedIn = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            //LoginViewModel viewModelentre = new LoginViewModel { LoggedIn = HttpContext.User.Identity.IsAuthenticated };
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Login");
            }

            utilisateurentreprise utilisateurentreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name));
            bool paiementNExistePas = utilisateurentreprise.Nocartebancaire == null;

            bool docNExistePas = utilisateurentreprise.entreprise.document_entreprise == null || utilisateurentreprise.entreprise.document_entreprise.Count() == 0;
            if (paiementNExistePas || docNExistePas)
            {
                return RedirectToAction("PieceManquant");
            }
            // return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                utilisateurentreprise entreprise = dalEntreprise.AuthentifierEntreprise(viewModel.adress_mail, viewModel.mot_de_passe);
                if (entreprise != null)
                {
                    FormsAuthentication.SetAuthCookie(CookieUtil.generateCookieValue("entreprise", entreprise.idUtilisateurEntreprise), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/UserEntreprise/Index");

                }
                ModelState.AddModelError("utilisateurentreprise.adresse_emailUE", "wrong login");
                //view??? error
            }
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult PieceManquant()
        {
            LoginViewModel viewModelentre = new LoginViewModel { LoggedIn = HttpContext.User.Identity.IsAuthenticated };

            utilisateurentreprise utilisateurentreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name));
           
            viewModelentre.paiementNExistePas = utilisateurentreprise.Nocartebancaire == null;
            viewModelentre.docNExistePas = utilisateurentreprise.entreprise.document_entreprise == null || utilisateurentreprise.entreprise.document_entreprise.Count() == 0;
            
            if (viewModelentre.paiementNExistePas || viewModelentre.docNExistePas)
            {
                return View(viewModelentre);
            }

            return Redirect("/UserEntreprise/Index");
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
                var EntreprisemailAlreadyExists = dalEntreprise.getUtilisateurEntrepriseParEmail(utilisateur.adresse_mailUE.ToLower());
                if (EntreprisemailAlreadyExists != null)
                {
                    ModelState.AddModelError("Username", "This username already exists");
                    return View();
                }
                int id = dalEntreprise.AjouterUserEntreprise(utilisateur.adresse_mailUE, utilisateur.mot_de_passeUE, utilisateur.entreprise);
                FormsAuthentication.SetAuthCookie(CookieUtil.generateCookieValue("entreprise", id), false);
                return RedirectToAction("paiement");
                //lier avec le page d'accueil d'artiste
            }
            return View(utilisateur);
        }








        public ActionResult paiement()
        {
            CreerEntrepriseViewModel creerEntrepriseViewModel = new CreerEntrepriseViewModel();
            List<SelectListItem> list = new List<SelectListItem>();
            List<SelectListItem> list2 = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                list.Add(new SelectListItem { Text = i + "", Value = i + "", Selected = false });
            }
            for (int i = 2020; i <= 2030; i++)
            {
                list2.Add(new SelectListItem { Text = i + "", Value = i + "", Selected = false });
            }


            creerEntrepriseViewModel.SelectedMoisIds = new List<int>();
            creerEntrepriseViewModel.MoisList = list;

            creerEntrepriseViewModel.SelectedAnneeIds = new List<int>();
            creerEntrepriseViewModel.AnneeList = list2;
            return View(creerEntrepriseViewModel);
        }

        [HttpPost]
        public ActionResult paiement(CreerEntrepriseViewModel utilisateur)
        {
            if (ModelState.IsValid)
            {
                utilisateurentreprise utilisateurentreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name));
                // int id = dalEntreprise.AjouterUserEntreprise(utilisateur.adresse_mailUE, utilisateur.mot_de_passeUE, utilisateur.entreprise);
                utilisateurentreprise.Nocartebancaire = utilisateur.utilisateurentreprise.Nocartebancaire;
                utilisateurentreprise.AnneeExpiration = "" + utilisateur.SelectedAnneeIds.First();
                utilisateurentreprise.MoisExpiration = "" + utilisateur.SelectedMoisIds.First();
                utilisateurentreprise.CodeVerfication = utilisateur.utilisateurentreprise.CodeVerfication;
                //utilisateurentreprise =utilisateur ;
                dalEntreprise.context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
       
    }
}