
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;
namespace Art_fundingV0.Controllers
{
    public class RedigerMailController : Controller
    {
 
        [HttpGet]
public ActionResult ContactAsync()
{
    return View();
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> ContactAsync(Models.ContactModel model)
{
    if (ModelState.IsValid)
    {
        var mail = new MailMessage();
        mail.To.Add(new MailAddress(model.SenderEmail));
        mail.Subject = "Your Email Subject";
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