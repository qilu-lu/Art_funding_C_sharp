using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Art_fundingV0.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string type = CookieUtil.getTypeFromCookie(HttpContext.User.Identity.Name);
                if (type.Equals("entreprise"))
                {
                    return RedirectToAction("Index", "UserEntreprise");
                }
                else
                {
                    return RedirectToAction("Index", "UserArtiste");
                }
            }

            return View();
        }

        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}