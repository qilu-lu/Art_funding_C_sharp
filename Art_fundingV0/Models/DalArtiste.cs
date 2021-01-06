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

        internal bool VerificationContrat()
        {
            throw new NotImplementedException();
        }

        internal bool VerificationDocEmis()
        {
            throw new NotImplementedException();
        }

        public void SupprimerBoiteArtiste(int identreprise, int? idArtiste)
        {
            boite_artiste boiteArtiste = context.boite_artiste.FirstOrDefault(u => u.id_entreprise == identreprise && u.id_artiste == idArtiste);
            context.boite_artiste.Remove(boiteArtiste);
            context.SaveChanges();
        }
        public void AjouterBoiteArtiste(int? idArtiste)
        {
            boite_artiste boiteArtiste = context.boite_artiste.FirstOrDefault(u=> u.id_artiste == idArtiste);
            context.boite_artiste.Add(boiteArtiste);
            context.SaveChanges();
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

        //public bool VerificationDocEmis(byte[] CNI, byte[] justifDom)
        //{
        //    if (context.document_artiste.FirstOrDefault(d => d.CNI == CNI && d.justificatif_de_domicile == justifDom) == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        public bool VerificationDoc(int id)
        {
            if (context.document_artiste.FirstOrDefault(d => d.id_artiste==id) == null)
            {
                return false;
            }
            return true;
        }

        public bool VerificationContrat(int id)
        {
            if (context.contrat_ecole.FirstOrDefault(d => d.artiste_id == id) == null)
            {
                return false;
            }
            return true;
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


        public byte[] ObtientPhoto(int id)
        {
            return context.photos.FirstOrDefault(u => u.idphoto == id).photo1;
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

        public List<boite_artiste> ObtientTousLesBoites()
        {
            return context.boite_artiste.ToList();
        }

        public List<boite_artiste> ObtientTousLesBoitesparentreprise(int id)
        {
            List<boite_artiste> liste = context.boite_artiste.Where(boite => boite.id_entreprise == id).ToList();
         /*   List<boite_artiste> liste2 = new List<boite_artiste>();
            foreach (boite_artiste boite in liste)
            {
                if (boite.id_entreprise == id)
                {
                    liste2.Add(boite);
                }
            }*/
            return liste;
        }
       


        public boite_artiste ObtientTousLesBoites(int id)
        {
            return context.boite_artiste.FirstOrDefault(u => u.idBoite_Artiste == id);
        }

        //public List<artiste> ObtientArtistesContacte(int idEntreprise)
        //{
        //    List<boite_artiste> listeBoite = context.boite_artiste.Where(boite => boite.id_entreprise == idEntreprise && boite.etat == "Contacte").ToList();
        //    List<artiste> listeartiste = new List<artiste>();
        //    foreach (boite_artiste boite in listeBoite)
        //    {
        //        listeartiste.Add(boite.artiste);
        //    }
          
        //    return listeartiste;
        //}

        public void Dispose()
        {
            context.Dispose();
        }

        public utilisateurartiste getUtilisateurArtisteParEmail(string mail)
        {
            return context.utilisateurartistes.FirstOrDefault(u => u.mailUA == mail);
        }
        public List<artiste> RechercheArtistes(string SearchString)
        {
            List<artiste> artistes = context.artistes.Where(a => a.nom.Contains(SearchString) || a.categorie.nom.Contains(SearchString) || a.prenom.Contains(SearchString)).ToList();
            return artistes;
        }
        public List<artiste> ObtientArtistesContacte(int idEntreprise)
        {
            List<boite_artiste> listeBoite = context.boite_artiste.Where(boite => boite.id_entreprise == idEntreprise && boite.etat == "Contacte").ToList();
            List<artiste> artistes = new List<artiste>();
            foreach (boite_artiste Boite in listeBoite)
            {
                artistes.Add(Boite.artiste);
            }
            return artistes;
        }
        //public List<artiste> TrouverLesArtistesFinances(int idBoiteArtisteContactes)
        //{
        //    List<boite_artiste> listeDossierFinancement = context.boite_artiste.Where(boite => boite.id_entreprise == idBoiteArtisteContactes && boite.etat == "contacte" && boite.artiste.contrat_ecole!=null).ToList();
        //    List<artiste> artistesFinances = new List<artiste>();
        //    foreach (boite_artiste artisteFi in listeDossierFinancement)
        //    { if(artisteFi.artiste.contrat_ecole.Count()>0)
        //        artistesFinances.Add(artisteFi.artiste);
        //    }
        //    return artistesFinances;
        //}
    }
}



