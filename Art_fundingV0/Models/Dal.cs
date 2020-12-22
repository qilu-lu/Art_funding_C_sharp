using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Art_fundingV0.Models
{ 
    public class Dal : IDal 
    {
        private BddContext context;

        public Dal()
        {
            context = new BddContext();
        }

        public void CreerArtiste(string nom, string prenom, DateTime date_de_naissance, string adresse, string code_postale, string ville, string pays, string mail, string numero, int projet_id, string description, long ecole_choisie_id, int? formation_choisie_id, string mot_de_passe, DateTime? disponibilite, int categorie_id)
        {
            artiste artiste = new artiste()
            {
                nom = nom,
                prenom = prenom,
                date_de_naissance = date_de_naissance,
                adresse = adresse,
                code_postale = code_postale,
                ville = ville,
                pays = pays,
                mail = mail,
                numero = numero,
                projet_id = projet_id,
                description = description,
                ecole_choisie_id = ecole_choisie_id,
                formation_choisie_id = formation_choisie_id,
                mot_de_passe = mot_de_passe,
                Disponibilite = disponibilite,
                categorie_id = categorie_id
            };
            context.Artistes.Add(artiste);
            context.SaveChanges();

        }
        public int AjouterUserEntreprise(string adresse_mailUE, string mot_de_passeUE)
        {
            string encodedPassword = EncodeMD5(mot_de_passeUE);
            utilisateurentreprise userToAdd = new utilisateurentreprise
            {
                adresse_mailUE = adresse_mailUE,
                mot_de_passeUE = mot_de_passeUE,
                role="entreprise"

            };
            context.utilisateurentreprises.Add(userToAdd);
            context.SaveChanges();
            return userToAdd.idUtilisateurEntreprise;
        }

        public int AjouterUserArtiste(string mailUA, string mot_de_passeUA)
        {
            string encodedPassword = EncodeMD5(mot_de_passeUA);
           utilisateurartiste userToAdd = new utilisateurartiste
           {
               mailUA = mailUA,
               mot_de_passeUA = mot_de_passeUA,
               role="artiste"
                
            };
            context.utilisateurartistes.Add(userToAdd);
            context.SaveChanges();
            return userToAdd.idartiste.Value;
        }

        public void CreerEntreprise(string denomination_Commerciale, string raison_Sociale, string nom_de_l_ayant_droit, string prenom_de_l_ayant_droit, string fonction_au_sein_de_l_entreprise, string adresse, int code_postale, string ville, string pays, string adresse_email, string numero, int? artiste_choisi_id, int contrat_abonnement_id, int? contrat_avec_artiste_id, string mot_de_passe, string SIRET)
        {
            entreprise entreprise = new entreprise()
            {
                denomination_Commerciale = denomination_Commerciale,
                raison_Sociale = raison_Sociale,
                nom_de_l_ayant_droit = nom_de_l_ayant_droit,
                prenom_de_l_ayant_droit = prenom_de_l_ayant_droit,
                fonction_au_sein_de_l_entreprise = fonction_au_sein_de_l_entreprise,
                adresse = adresse,
                code_postale = code_postale,
                ville = ville,
                pays = pays,
                adresse_email = adresse_email,
                numero = numero,
                artiste_choisi_id = artiste_choisi_id,
                contrat_abonnement_id = contrat_abonnement_id,
                contrat_avec_artiste_id = contrat_avec_artiste_id,
                mot_de_passe = mot_de_passe,
                SIRET = SIRET
            };
            context.Entreprises.Add(entreprise);
            context.SaveChanges();
        }



        public void ModifierArtiste(int idartiste, string nom, string prenom, DateTime date_de_naissance, string adresse, string code_postale, string ville, string pays, string mail, string numero, int projet_id, string description, long ecole_choisie_id, int? formation_choisie_id, string mot_de_passe, DateTime? disponibilite, int categorie_id)
        {


            artiste artiste = context.Artistes.Find(idartiste);
            if (artiste != null)
            {
                artiste.nom = nom;
                artiste.prenom = prenom;
                artiste.date_de_naissance = date_de_naissance;
                artiste.adresse = adresse;
                artiste.code_postale = code_postale;
                artiste.ville = ville;
                artiste.pays = pays;
                artiste.mail = mail;
                artiste.numero = numero;
                artiste.projet_id = projet_id;
                artiste.description = description;
                artiste.ecole_choisie_id = ecole_choisie_id;
                artiste.formation_choisie_id = formation_choisie_id;
                artiste.mot_de_passe = mot_de_passe;
                artiste.Disponibilite = disponibilite;
                artiste.categorie_id = categorie_id;
            }

            context.SaveChanges();
        }

        public void ModifierEntreprise(int identreprise, string denomination_Commerciale, string raison_Sociale, string nom_de_l_ayant_droit, string prenom_de_l_ayant_droit, string fonction_au_sein_de_l_entreprise, string adresse, int code_postale, string ville, string pays, string adresse_email, string numero, int? artiste_choisi_id, int contrat_abonnement_id, int? contrat_avec_artiste_id, string mot_de_passe, string SIRET)
        {
            entreprise entreprise = context.Entreprises.Find(identreprise);
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
                entreprise.mot_de_passe = mot_de_passe;
                entreprise.SIRET = SIRET;
            }
            context.SaveChanges();

        }

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
            return context.utilisateurartistes.FirstOrDefault(u => u.mailUA == mail && u.mot_de_passeUA == motDePasseEncode);
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


    public List<artiste> ObtientTousLesArtistes()
        {
            return context.Artistes.ToList();
        }


        public artiste ObtientTousLesArtistes(int id)
        {
            return context.Artistes.FirstOrDefault(u => u.idartiste == id);
        }

        public artiste ObtientTousLesArtistes(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return ObtientTousLesArtistes(id);
            return null;
        }


        public List<entreprise> ObtientToutesLesEntreprises()
        {
            return context.Entreprises.ToList();
        }
        public entreprise ObtientToutesLesEntreprises(int id)
        {
            return context.Entreprises.FirstOrDefault(u => u.identreprise == id);
        }

        public entreprise ObtientToutesLesEntreprises(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return ObtientToutesLesEntreprises(id);
            return null;
        }

        public void Dispose()
        {
            context.Dispose();
        }

   
    }
}



