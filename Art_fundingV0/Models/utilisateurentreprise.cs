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
    
    public partial class utilisateurentreprise
    {
        public int idUtilisateurEntreprise { get; set; }
        public string adresse_mailUE { get; set; }
        public string mot_de_passeUE { get; set; }
        public Nullable<int> identreprise { get; set; }
        public string role { get; set; }

        public virtual entreprise entreprise { get; set; }
    }
}