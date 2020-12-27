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

      
        //public int AjouterUserEntreprise(string adresse_mailUE, string mot_de_passeUE, entreprise entrepriseX)
        //{
        //    string encodedPassword = EncodeMD5(mot_de_passeUE);
        //    entrepriseX.adresse_email = adresse_mailUE;
        //    utilisateurentreprise userToAdd = new utilisateurentreprise
        //    {
        //        adresse_mailUE = adresse_mailUE,
        //        mot_de_passeUE = encodedPassword,
        //        //role="entreprise"
        //        entreprise=entrepriseX
                
               
        //    };
        //    //entreprise.mot_de_passe = encodedPassword;
        //    context.utilisateurentreprises.Add(userToAdd);

        //        context.SaveChanges();
            
           
        //    return userToAdd.idUtilisateurEntreprise;
        //}

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
               mot_de_passe = mot_de_passeUA,
               //role="artiste"
               artiste=artiste ,
             //ecole =artiste.ecole
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

        //public void ajouterEntreprise(entreprise entreprise)
        //{
           
            
        //    entreprise t=context.entreprises.Add(entreprise);
        //    context.SaveChanges();
        //}
        //public void ajouterArtiste(artiste artiste)
        //{


        //    context.artistes.Add(artiste);
        //    context.SaveChanges();
        //}



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

        //public void ModifierEntreprise(int identreprise, string denomination_Commerciale, string raison_Sociale, string nom_de_l_ayant_droit, string prenom_de_l_ayant_droit, string fonction_au_sein_de_l_entreprise, string adresse, int code_postale, string ville, string pays, string adresse_email, string numero, int? artiste_choisi_id, int contrat_abonnement_id, int? contrat_avec_artiste_id, string mot_de_passe, string SIRET)
        //{
        //    entreprise entreprise = context.entreprises.Find(identreprise);
        //    if (entreprise != null)
        //    {
        //        entreprise.denomination_Commerciale = denomination_Commerciale;
        //        entreprise.raison_Sociale = raison_Sociale;
        //        entreprise.nom_de_l_ayant_droit = nom_de_l_ayant_droit;
        //        entreprise.prenom_de_l_ayant_droit = prenom_de_l_ayant_droit;
        //        entreprise.fonction_au_sein_de_l_entreprise = fonction_au_sein_de_l_entreprise;
        //        entreprise.adresse = adresse;
        //        entreprise.code_postale = code_postale;
        //        entreprise.ville = ville;
        //        entreprise.pays = pays;
        //        entreprise.adresse_email = adresse_email;
        //        entreprise.numero = numero;
        //        entreprise.artiste_choisi_id = artiste_choisi_id;
        //        entreprise.contrat_abonnement_id = contrat_abonnement_id;
        //        entreprise.contrat_avec_artiste_id = contrat_avec_artiste_id;
        //        entreprise.SIRET = SIRET;
        //    }
        //    context.SaveChanges();

        //}

    //public void SupprimerArtiste(int idartiste, string nom, string prenom, DateTime date_de_naissance, string adresse, string code_postale, string ville, string pays, string mail, string numero, int projet_id, string description, long ecole_choisie_id, int? formation_choisie_id, string mot_de_passe, DateTime? Disponibilite, int categorie_id)
    //{
    //    throw new NotImplementedException();
    //}



    //public void SupprimerEntreprise(int identreprise, string denomination_Commerciale, string raison_Sociale, string nom_de_l_ayant_droit, string prenom_de_l_ayant_droit, string fonction_au_sein_de_l_entreprise, string adresse, int code_postale, string ville, string pays, string adresse_email, string numero, int? artiste_choisi_id, int contrat_abonnement_id, int? contrat_avec_artiste_id, string mot_de_passe, string SIRET)
    //{
    //    throw new NotImplementedException();
    //}
    public utilisateurartiste AuthentifierArtiste(string mail, string motDePasse)
    {
        string motDePasseEncode = EncodeMD5(motDePasse);
            return context.utilisateurartistes.FirstOrDefault(u => u.mailUA == mail && u.mot_de_passe == motDePasseEncode);
    }
    //    public utilisateurentreprise AuthentifierEntreprise(string mail, string motDePasse)
    //    {
    //        string motDePasseEncode = EncodeMD5(motDePasse);
    //        return context.utilisateurentreprises.FirstOrDefault(u => u.adresse_mailUE == mail && u.mot_de_passeUE == motDePasseEncode);
    //    }

        
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
        //public List<categorie>ObtientTousLesCategories()
        //{
        //    return context.categories.ToList();
        //}
       


        //public List<entreprise> ObtientToutesLesEntreprises()
        //{
        //    return context.entreprises.ToList();
        //}
        //public entreprise ObtientToutesLesEntreprises(int id)
        //{
        //    return context.entreprises.FirstOrDefault(u => u.identreprise == id);
        //}

        //public utilisateurentreprise ObtientUtilisateurE(int id)
        //{
        //    return context.utilisateurentreprises.FirstOrDefault(u => u.idUtilisateurEntreprise == id);
        //}
        public utilisateurartiste ObtientUtilisateurA(int id)
        {
            return context.utilisateurartistes.FirstOrDefault(u => u.idUtilisateurArtiste == id);
        }

        //public utilisateurentreprise ObtientToutesLesEntreprises(string idString)
        //{
        //    int id;
        //    if (int.TryParse(idString, out id))
        //        return ObtientUtilisateurE(id);
        //    return null;
        //}
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

        //public utilisateurentreprise getUtilisateurEntrepriseParEmail(string mail)
        //{
        //    return context.utilisateurentreprises.FirstOrDefault(u => u.adresse_mailUE == mail);
        //}
        public utilisateurartiste getUtilisateurArtisteParEmail(string mail)
        {
            return context.utilisateurartistes.FirstOrDefault(u => u.mailUA == mail);
        }
        //public ecole GetEcoleParId(int id)
        //{
        //    return context.ecoles.FirstOrDefault(u => u.idecole == id);
        //}

        //public List<ecole> ObtientTousLesEcoles()
        //{
        //    return context.ecoles.ToList();
        //}

    }
}



