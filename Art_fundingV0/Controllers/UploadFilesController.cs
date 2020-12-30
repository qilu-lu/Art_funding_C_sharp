using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Art_fundingV0.Models;
namespace Art_fundingV0.Controllers
{
    public class UploadFilesController : Controller
    {
        private art_fundingEntities context = new art_fundingEntities();
        // GET: UploadFiles

        public ActionResult TelechargerDocs()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult TelechargerDocs([Bind(Include = "iddocument_entreprise, Attestation_assurance,Kbis,RIB ")] document_entreprise document_Entreprise, HttpPostedFileBase file, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            
            if (ModelState.IsValid)
            {
                // convert file choose by user into byte[]
                if (file.ContentLength > 0&& file2.ContentLength > 0 && file3.ContentLength > 0 && file4.ContentLength > 0)
                {
                    byte[] imageData = null;
                    byte[] imageData2 = null;
                    byte[] imageData3 = null;
                    byte[] imageData4 = null;

                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(file.ContentLength);
                    }
                    using (var binaryReader = new BinaryReader(file2.InputStream))
                    {
                        imageData2 = binaryReader.ReadBytes(file2.ContentLength);
                    }
                    using (var binaryReader = new BinaryReader(file3.InputStream))
                    {
                        imageData3 = binaryReader.ReadBytes(file3.ContentLength);
                    }
                    using (var binaryReader = new BinaryReader(file4.InputStream))
                    {
                        imageData4 = binaryReader.ReadBytes(file4.ContentLength);
                    }
                    document_Entreprise.Attestation_assurance = imageData;
                    document_Entreprise.Kbis = imageData2;
                    document_Entreprise.RIB = imageData3;
                    document_Entreprise.Dernier_statut = imageData4;
                    int id;
                    if (int.TryParse(HttpContext.User.Identity.Name, out id)) { 
                    entreprise entreprise = context.entreprises.Find(id);
                
                   
                    document_Entreprise.entreprise=entreprise;
                   

                    context.document_entreprise.Add(document_Entreprise);
                    context.SaveChanges();
                    ViewBag.success = "Uploaded Filed Saved Succesfully in a folder!";
                    return RedirectToAction("TelechargerDocs");
                    }
                }
            }

           

            return View(document_Entreprise);
          
        }
    }
}
