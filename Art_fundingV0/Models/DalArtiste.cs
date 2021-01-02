using Art_fundingV0.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Art_fundingV0.Models
{ 
    public class DalArtiste : IDalArtiste 
    {
        private art_fundingEntities context;

        public DalArtiste()
        {
            context = new art_fundingEntities();
        }

      
        public int AjouterUserArtiste(string mailUA, string mot_de_passeUA, CreerArtisteViewModel creerArtiste)
        {
            artiste artiste = creerArtiste.utilisateurartiste.artiste;
            //artiste.ecole_choisie_id = ecole_choisie_id;
            artiste.ecole = context.ecoles.Find(creerArtiste.SelectedEcoleIds.First());
            artiste.categorie= context.categories.Find(creerArtiste.SelectedCategorieIds.First());
            string encodedPassword = EncodeMD5(mot_de_passeUA);

           utilisateurartiste userToAdd = new utilisateurartiste
           {
               mailUA = mailUA,
               mot_de_passe = encodedPassword,
               artiste =artiste 
            
            };
            context.utilisateurartistes.Add(userToAdd);
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return userToAdd.idUtilisateurArtiste;
        }

       
        public void ModifierArtiste(int idartiste, string nom, string prenom, DateTime date_de_naissance, string adresse, string code_postale, string ville, string pays, string mail, string numero, int projet_id, string description, long ecole_choisie_id, int? formation_choisie_id, string mot_de_passe, DateTime? disponibilite, int categorie_id)
        {


            artiste artiste = context.artistes.Find(idartiste);
            if (artiste != null)
            {
                artiste.nom = nom;
                artiste.prenom = prenom;
                artiste.date_de_naissance = date_de_naissance;
                artiste.adresse = adresse;
                artiste.code_postale = code_postale;
                artiste.ville = ville;
                artiste.pays = pays;
                artiste.numero = numero;
                artiste.description = description;
                artiste.ecole_choisie_id = ecole_choisie_id;
                artiste.formation_choisie_id = formation_choisie_id;
                artiste.Disponibilite = disponibilite;
                artiste.categorie_id = categorie_id;
            }

            context.SaveChanges();
        }

    public utilisateurartiste AuthentifierArtiste(string mail, string motDePasse)
    {
        string motDePasseEncode = EncodeMD5(motDePasse);
            return context.utilisateurartistes.FirstOrDefault(u => u.mailUA == mail && u.mot_de_passe == motDePasseEncode);
    }




        private string EncodeMD5(string motDePasse)
    {
        string motDePasseSel = "email" + motDePasse + "ASP.NET MVC";
        return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
    }


    public List<artiste> ObtientTousLesArtistes()
       {
            return context.artistes.ToList();
        }


        public artiste ObtientTousLesArtistes(int id)
        {
            return context.artistes.FirstOrDefault(u => u.idartiste == id);
        }
      
        public utilisateurartiste ObtientUtilisateurA(int id)
        {
            return context.utilisateurartistes.FirstOrDefault(u => u.idUtilisateurArtiste == id);
        }

       
        public utilisateurartiste ObtientTousLesArtistes(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return ObtientUtilisateurA(id);
            return null;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public utilisateurartiste getUtilisateurArtisteParEmail(string mail)
        {
            return context.utilisateurartistes.FirstOrDefault(u => u.mailUA == mail);
        }
        

    }
}



