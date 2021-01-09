using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.Controllers
{
    public class PopUpController : Controller
    {
        // GET: PopUp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PopUp()
        {
            return View();
        }
    }
}