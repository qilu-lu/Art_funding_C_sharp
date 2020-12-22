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
    public class usersController : Controller
    {
        private IDal dal;
        public usersController() : this(new Dal())
        {
        }
        private usersController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        public ActionResult Index()
        {
            LoginViewModel viewModel = new LoginViewModel { LoggedIn = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string username = viewModel.Username;
                string password = viewModel.Password;
                user user = new user() { username = username, password = password };
                user = dal.ObtenirUtilisateur(HttpContext.User.Identity.Name);
            }
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                user utilisateur = dal.Authentifier(viewModel.Username, viewModel.Password);
                if (utilisateur != null)
                {
                    FormsAuthentication.SetAuthCookie(utilisateur.user_id.ToString(), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }
                ModelState.AddModelError("Utilisateur.username", "wrong login");
            }
            return View(viewModel);
        }
        public ActionResult CreerCompte()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreerCompte(CreateUserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //verifie si le compte existe deja
                var isUsernameAlreadyExists = dal.ObtenirUtilisateurs().Any(u => u.username.ToLower() == vm.Username.ToLower());
                if (isUsernameAlreadyExists)
                {
                    ModelState.AddModelError("Username", "This username already exists");
                    return View(vm);
                }
                int id = dal.AjouterUtilisateur(vm.Username, vm.Password);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);
                return Redirect("/");
            }
            return View(vm);
        }
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}