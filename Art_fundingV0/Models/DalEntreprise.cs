using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Art_fundingV0.Models
{
    public class DalEntreprise : IDalEntreprise
    {
        public art_fundingEntities context;

        public DalEntreprise()
        {
            context = new art_fundingEntities();
        }
        public int AjouterUserEntreprise(string adresse_mailUE, string mot_de_passeUE,entreprise entrepriseX)
        {
            string encodedPassword = EncodeMD5(mot_de_passeUE);
            entrepriseX.adresse_email = adresse_mailUE;
           

            utilisateurentreprise userToAdd = new utilisateurentreprise
            {
                adresse_mailUE = adresse_mailUE,
                mot_de_passeUE = encodedPassword,
               
            //role="entreprise"
                entreprise = entrepriseX


            };
            //entreprise.mot_de_passe = encodedPassword;
            context.utilisateurentreprises.Add(userToAdd);

            context.SaveChanges();


            return userToAdd.idUtilisateurEntreprise;
        }
        public void ModifierEntreprise(int identreprise, string denomination_Commerciale, string raison_Sociale, string nom_de_l_ayant_droit, string prenom_de_l_ayant_droit, string fonction_au_sein_de_l_entreprise, string adresse, int code_postale, string ville, string pays, string adresse_email, string numero, int? artiste_choisi_id, int contrat_abonnement_id, int? contrat_avec_artiste_id, string mot_de_passe, string SIRET)
        {
            entreprise entreprise = context.entreprises.Find(identreprise);
            if (entreprise != null)
            {
                entreprise.denomination_Commerciale = denomination_Commerciale;
                entreprise.raison_Sociale = raison_Sociale;
                entreprise.nom_de_l_ayant_droit = nom_de_l_ayant_droit;
                entreprise.prenom_de_l_ayant_droit = prenom_de_l_ayant_droit;
                entreprise.fonction_au_sein_de_l_entreprise = fonction_au_sein_de_l_entreprise;
                entreprise.adresse = adresse;
                entreprise.code_postale = code_postale;
                entreprise.ville = ville;
                entreprise.pays = pays;
                entreprise.adresse_email = adresse_email;
                entreprise.numero = numero;
                entreprise.artiste_choisi_id = artiste_choisi_id;
                entreprise.contrat_abonnement_id = contrat_abonnement_id;
                entreprise.contrat_avec_artiste_id = contrat_avec_artiste_id;
                entreprise.SIRET = SIRET;
            }
            context.SaveChanges();

        }
    
        public utilisateurentreprise AuthentifierEntreprise(string mail, string motDePasse)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            return context.utilisateurentreprises.FirstOrDefault(u => u.adresse_mailUE == mail && u.mot_de_passeUE == motDePasseEncode);
        }


        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "email" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
        public List<entreprise> ObtientToutesLesEntreprises()
        {
            return context.entreprises.ToList();
        }
        public entreprise ObtientToutesLesEntreprises(int id)
        {
            return context.entreprises.FirstOrDefault(u => u.identreprise == id);
        }

        public utilisateurentreprise ObtientUtilisateurE(int id)
        {
            return context.utilisateurentreprises.FirstOrDefault(u => u.idUtilisateurEntreprise == id);
        }
        public utilisateurentreprise ObtientToutesLesEntreprises(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return ObtientUtilisateurE(id);
            return null;
        }
        public utilisateurentreprise getUtilisateurEntrepriseParEmail(string mail)
        {
            return context.utilisateurentreprises.FirstOrDefault(u => u.adresse_mailUE == mail);
        }
        public utilisateurentreprise getUtilisateurEntrepriseParid(int id)
        {
            return context.utilisateurentreprises.FirstOrDefault(u => u.identreprise == id);
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}