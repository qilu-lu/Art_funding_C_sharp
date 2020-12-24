﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_fundingV0.Models
{
    interface IDal:IDisposable
    {
        void CreerArtiste(string nom, string prenom,DateTime date_de_naissance, string adresse, string code_postale, string ville,
        string pays, string mail, string numero, int projet_id, string description, long ecole_choisie_id, Nullable<int> formation_choisie_id, string mot_de_passe, Nullable<System.DateTime> Disponibilite, int categorie_id);

        void ajouterEntreprise(entreprise entreprise);
        int  AjouterUserEntreprise(string adresse_mailUE, string mot_de_passeUE);
        int AjouterUserArtiste(string mailUA, string mot_de_passeUA);
       
        utilisateurentreprise AuthentifierEntreprise(string adresse_mailUE, string mot_de_passeUE);
        utilisateurartiste AuthentifierArtiste(string mailUA, string mot_de_passeUA);

        void ModifierArtiste(int idartiste,string nom, string prenom, DateTime date_de_naissance, string adresse, string code_postale, string ville,
        string pays, string mail, string numero, int projet_id, string description, long ecole_choisie_id, Nullable<int> formation_choisie_id, string mot_de_passe, Nullable<System.DateTime> Disponibilite, int categorie_id);

        void ModifierEntreprise(int identreprise,string denomination_Commerciale, string raison_Sociale, string nom_de_l_ayant_droit, string prenom_de_l_ayant_droit, string fonction_au_sein_de_l_entreprise, string adresse,
        int code_postale, string ville, string pays, string adresse_email, string numero, Nullable<int> artiste_choisi_id, int contrat_abonnement_id, Nullable<int> contrat_avec_artiste_id, string mot_de_passe, string SIRET);

        //void SupprimerArtiste(int idartiste,string nom, string prenom, DateTime date_de_naissance, string adresse, string code_postale, string ville,
        //string pays, string mail, string numero, int projet_id, string description, long ecole_choisie_id, Nullable<int> formation_choisie_id, string mot_de_passe, Nullable<System.DateTime> Disponibilite, int categorie_id);

        //void SupprimerEntreprise(int identreprise,string denomination_Commerciale, string raison_Sociale, string nom_de_l_ayant_droit, string prenom_de_l_ayant_droit, string fonction_au_sein_de_l_entreprise, string adresse,
        //int code_postale, string ville, string pays, string adresse_email, string numero, Nullable<int> artiste_choisi_id, int contrat_abonnement_id, Nullable<int> contrat_avec_artiste_id, string mot_de_passe, string SIRET);


        List<artiste> ObtientTousLesArtistes();
        artiste ObtientTousLesArtistes(int id);
        artiste ObtientTousLesArtistes(string idStr);

        List<entreprise> ObtientToutesLesEntreprises();
        entreprise ObtientToutesLesEntreprises(int id);
        entreprise ObtientToutesLesEntreprises(string idStr);




      

        
    }
}
