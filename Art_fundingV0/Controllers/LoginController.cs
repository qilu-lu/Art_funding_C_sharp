using Art_fundingV0.Models;
using Art_fundingV0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Art_fundingV0.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private IDal dal;

        public LoginController() : this(new Dal())
        {

        }

        private LoginController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Login
        public ActionResult Index()
        {
            EntrepriseViewModel viewModelentre = new EntrepriseViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                //EntrepriseViewModel.entreprise = dal.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name);
            }
            return View();
        } } }

      //  [HttpPost]

      //  public ActionResult Index(EntrepriseViewModel viewModel, string returnUrl)
      //  {
       //     if (ModelState.IsValid)
        //    {
            //    Utilisateur utilisateur = dal.Authentifier(viewModel.entreprise.Prenom, viewModel.entreprise.MotDePasse);
           //     if (entreprise != null)
          //      {
            //        FormsAuthentication.SetAuthCookie(entreprise.Id.ToString(), false);
            //        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            //            return Redirect(returnUrl);
            //        return Redirect("/");
             //   }
              //  ModelState.AddModelError("entreprise.adresse_email", "adresse_email et/ou mot de passe incorrect(s)");
           // }
         //   return View();
      //  }
   // }
//}