using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.Controllers
{
    public class InfoArtFundingController : Controller
    {
        // GET: InfoArtFunding
        public ActionResult InfoArtFunding()
        {
            return View();
        }

        public ActionResult Partenaires()
        {
            return View();
        }
        public ActionResult QuiSommeNous()
        {
            return View();
        }
    }
}