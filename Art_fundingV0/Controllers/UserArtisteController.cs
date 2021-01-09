﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Art_fundingV0.Models;
using Art_fundingV0.ViewModels;
namespace Art_fundingV0.Controllers
{
    public class UserArtisteController : Controller
    {


        private IDalArtiste dalArtiste;
        private IDalEntreprise dalEntreprise;
        private IDalEcole dalEcole;
        private art_fundingEntities context = new art_fundingEntities();
        public UserArtisteController() : this(new DalArtiste(), new DalEcole())
        {
        }
        private UserArtisteController(IDalArtiste dalIoc, IDalEcole dalecolen)
        {
            dalArtiste = dalIoc;
            dalEcole = dalecolen;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel viewModelart = new LoginViewModel { LoggedIn = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {

                utilisateurartiste utilisateurartiste = dalArtiste.ObtientTousLesArtistes(HttpContext.User.Identity.Name);
                viewModelart.adress_mail = utilisateurartiste.mailUA;
                //  return Redirect("Index");
            }
            return View(viewModelart);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                utilisateurartiste artiste = dalArtiste.AuthentifierArtiste(viewModel.adress_mail, viewModel.mot_de_passe);
                if (artiste != null)
                {
                    FormsAuthentication.SetAuthCookie(artiste.idUtilisateurArtiste.ToString(), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("remplirphoto");
                }
                ModelState.AddModelError("utilisateurArtiste.mailUA", "wrong login");
                //view??? error
            }
            return View(viewModel);
        }

        public ActionResult CreerCompte()
        {
            CreerArtisteViewModel CreerArtisteViewModel = new CreerArtisteViewModel();
            List<SelectListItem> list = new List<SelectListItem>();
            List<SelectListItem> list2 = new List<SelectListItem>();

            foreach (ecole ecole in dalEcole.ObtientTousLesEcoles())
            {
                list.Add(new SelectListItem { Text = ecole.nom, Value = ecole.idecole + "", Selected = false });
            }
            CreerArtisteViewModel.SelectedEcoleIds = new List<int>();
            CreerArtisteViewModel.EcoleList = list;
            foreach (categorie categorie in dalEcole.ObtientTousLesCategories())
            {
                list2.Add(new SelectListItem { Text = categorie.nom, Value = categorie.id_categorie + "", Selected = false });
            }
            CreerArtisteViewModel.SelectedCategorieIds = new List<int>();

            CreerArtisteViewModel.CategorieList = list2;
            return View(CreerArtisteViewModel);
        }
        [HttpPost]
        public ActionResult CreerCompte(CreerArtisteViewModel creerArtiste)
        {
            if (ModelState.IsValid)
            {
                //verifie si le compte existe deja
                //                var isArtistemailAlreadyExists = dal.obtenirtouslesartistes().FirstOrDefault(u => u.mail.ToLower() == utilisateur.mailUA.ToLower());
                utilisateurartiste utilisateur = creerArtiste.utilisateurartiste;

                var isArtistemailAlreadyExists = dalArtiste.getUtilisateurArtisteParEmail(utilisateur.mailUA.ToLower());
                if (isArtistemailAlreadyExists != null)
                {
                    ModelState.AddModelError("Username", "This username already exists");
                    return View(utilisateur);
                }
                int id = dalArtiste.AjouterUserArtiste(utilisateur.mailUA, utilisateur.mot_de_passe, creerArtiste);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);

                return RedirectToAction("remplirphoto");
            }
            return View();
        }
        public ActionResult remplirphoto()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult remplirphoto(IEnumerable<HttpPostedFileBase> filesToUpload)
        {
            if (ModelState.IsValid)
            {
                artiste artiste = dalArtiste.ObtientTousLesArtistes(HttpContext.User.Identity.Name).artiste;
                int id = artiste.idartiste;
                foreach (HttpPostedFileBase fileToUpload in filesToUpload)
                {
                    if (fileToUpload != null && fileToUpload.ContentLength > 0)
                    {
                        byte[] imageData = null;
                        using (var binaryReader = new BinaryReader(fileToUpload.InputStream))
                        {
                            imageData = binaryReader.ReadBytes(fileToUpload.ContentLength);
                        }
                        photo photo = new photo();
                        photo.photo1 = imageData;
                        photo.idartist = id;
                        context.photos.Add(photo);
                        // document_Entreprise.entreprise = entreprise;
                    }
                }
                context.SaveChanges();
                return RedirectToAction("chargerDocs");
              
            }

            return View();
        }


        public ActionResult chargerDocs()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult chargerDocs([Bind(Include = "iddocument_artiste, CNI,justificatif domicile ")] document_artiste document_artiste, HttpPostedFileBase file, HttpPostedFileBase file2)
        {

            if (ModelState.IsValid)
            {
                // convert file choose by user into byte[]
                if (file.ContentLength > 0 && file2.ContentLength > 0)
                {
                    byte[] imageData = null;
                    byte[] imageData2 = null;
                   
                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(file.ContentLength);
                    }
                    using (var binaryReader = new BinaryReader(file2.InputStream))
                    {
                        imageData2 = binaryReader.ReadBytes(file2.ContentLength);
                    }
                   
                    document_artiste.CNI = imageData;
                    document_artiste.justificatif_de_domicile = imageData2;
                   
                    int id;
                    if (int.TryParse(HttpContext.User.Identity.Name, out id))
                    {
                        artiste artiste= context.utilisateurartistes.Find(id).artiste;


                        document_artiste.artiste = artiste;


                        context.document_artiste.Add(document_artiste);
                        context.SaveChanges();
                        ViewBag.success = "Uploaded Filed Saved Succesfully in a folder!";
                        return RedirectToAction("/", "UserArtiste");
                        
                    }
                }
            }



            return View(document_artiste);

        }

        public ActionResult AjouterContratecole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AjouterContratecole([Bind(Include = "iddocument_artiste, Contract_ecole ")] contrat_ecole contrat_Ecole, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                // convert file choose by user into byte[]
                if (file.ContentLength > 0 )
                {
                    byte[] imageData = null;
                

                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(file.ContentLength);
                    }
                    

                    contrat_Ecole.fichier_contrat = imageData;
                    

                    int id;
                    if (int.TryParse(HttpContext.User.Identity.Name, out id))
                    {
                        artiste artiste = context.utilisateurartistes.Find(id).artiste;


                        contrat_Ecole.artiste = artiste;


                        context.contrat_ecole.Add(contrat_Ecole);
                        context.SaveChanges();
                        ViewBag.success = "Uploaded Filed Saved Succesfully in a folder!";
                        return RedirectToAction("/", "UserArtiste");

                    }
                }
            }

            return View(contrat_Ecole);
        }

        public void getContrat(int idcontrat)
        {

            //Verfiier que c'est bien une entreprise qui est connectée
            byte[] fileContents = dalArtiste.ObtientContratEcole(idcontrat);
            Response.Clear();
            Response.AddHeader("Content-Length", fileContents.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=contrat.pdf");
            Response.OutputStream.Write(fileContents, 0, fileContents.Length);
            Response.Flush();
            Response.End();
            // return null;
        }



    }
}