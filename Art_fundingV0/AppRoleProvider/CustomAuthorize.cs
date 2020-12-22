using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.AppRoleProvider
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.authorize = false;

            //string retUrl = filterContext.HttpContext.Request.RawUrl;
            //filterContext.Result =
            //                 new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
            //                         {{ "controller", filterContext.Controller.ToString()},
            //                          { "action", filterContext.ActionDescriptor.ToString() },
            //                          { "returnUrl",    retUrl } });

            //filterContext.Result = new RedirectToRouteResult(new
            //RouteValueDictionary(new { controller = "Accueil", action = "Index" }));

        }
    }
}