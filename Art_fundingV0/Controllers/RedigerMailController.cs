
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
    { private IDalEntreprise dalEntreprise = new DalEntreprise();

        [HttpGet]
        public ActionResult ContactAsync()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ContactAsync(Models.ContactModel model)
        {
            entreprise entreprise = dalEntreprise.ObtientToutesLesEntreprises(HttpContext.User.Identity.Name).entreprise;
           
            if (ModelState.IsValid)
            {
                var mail = new MailMessage();
                mail.To.Add(new MailAddress(model.SenderEmail));
                mail.Subject = "ArtFunding - Une entreprise vous a envoye un message";
                model.SenderName = entreprise.artiste.nom;
                model.SenderEmail = entreprise.artiste.utilisateurartistes.First().mailUA;
                model.Message = "Vous avez recu un message de " + entreprise.raison_Sociale  + "<br>" + model.Message;
                mail.Body = string.Format("<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>", model.SenderName, model.SenderEmail, model.Message);
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