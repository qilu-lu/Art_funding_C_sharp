//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Art_fundingV0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class entreprise
    {
        public int identreprise { get; set; }
        public string denomination_Commerciale { get; set; }
        public string raison_Sociale { get; set; }
        public string nom_de_l_ayant_droit { get; set; }
        public string prenom_de_l_ayant_droit { get; set; }
        public string fonction_au_sein_de_l_entreprise { get; set; }
        public string adresse { get; set; }
        public int code_postale { get; set; }
        public string ville { get; set; }
        public string pays { get; set; }
        public string adresse_email { get; set; }
        public string numero { get; set; }
        public Nullable<int> artiste_choisi_id { get; set; }
        public int contrat_abonnement_id { get; set; }
        public Nullable<int> contrat_avec_artiste_id { get; set; }
        public string mot_de_passe { get; set; }
        public string SIRET { get; set; }
    
        public virtual artiste artiste { get; set; }
    }
}
