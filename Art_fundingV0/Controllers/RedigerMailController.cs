
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;
using Art_fundingV0.Models;

namespace Art_fundingV0.Controllers
{
    public class RedigerMailController : Controller
    {
        private IDalEntreprise dalEntreprise = new DalEntreprise();
        private IDalArtiste dalArtiste = new DalArtiste();

        [HttpGet]
        public ActionResult ContactAsync()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ContactAsync(Models.ContactModel model)
        {
            entreprise entreprise = dalEntreprise.ObtientUtilisateurE(CookieUtil.getIdFromCookie(HttpContext.User.Identity.Name)).entreprise;
            artiste artiste = dalArtiste.ObtientTousLesArtistes(model.artisteId);
            if (ModelState.IsValid)
            {
                var mail = new MailMessage();
                mail.Subject = "ArtFunding - Une entreprise vous a envoye un message";
                string SenderName = artiste.nom;
                string SenderEmail = artiste.utilisateurartistes.FirstOrDefault().mailUA;
                mail.To.Add(new MailAddress(SenderEmail));
                mail.Body = "Vous avez recu un message de " + entreprise.raison_Sociale + "<br>" + model.Message;
                mail.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(mail);
                    return RedirectToAction("SuccessMessage");
                }
            }
            return View(model);
        }
        public ActionResult SuccessMessage()
        {
            return View();
        }
    }
}