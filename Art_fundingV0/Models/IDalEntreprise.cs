using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art_fundingV0.Models
{
    interface IDalEntreprise : IDisposable
    {
      

        int AjouterUserEntreprise(string adresse_mailUE, string mot_de_passeUE,entreprise entrepriseX);
        utilisateurentreprise AuthentifierEntreprise(string adresse_mailUE, string mot_de_passeUE);

        void ModifierEntreprise(int identreprise, string denomination_Commerciale, string raison_Sociale, string nom_de_l_ayant_droit, string prenom_de_l_ayant_droit, string fonction_au_sein_de_l_entreprise, string adresse,
        int code_postale, string ville, string pays, string adresse_email, string numero, Nullable<int> artiste_choisi_id, int contrat_abonnement_id, Nullable<int> contrat_avec_artiste_id, string mot_de_passe, string SIRET);
        utilisateurentreprise getUtilisateurEntrepriseParEmail(string mail);
        List<entreprise> ObtientToutesLesEntreprises();
        entreprise ObtientToutesLesEntreprises(int id);
        utilisateurentreprise ObtientToutesLesEntreprises(string idStr);
        utilisateurentreprise getUtilisateurEntrepriseParid(int id);
        void AjouterArtisteContacte(int idBoiteArtiste);
       




    }
}