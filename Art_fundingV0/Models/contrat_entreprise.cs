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
    
    public partial class contrat_entreprise
    {
        public int idContrat_entreprise { get; set; }
        public byte[] fichier_contrat { get; set; }
        public Nullable<int> entreprise_id { get; set; }
        public Nullable<int> ecole_id { get; set; }
        public Nullable<int> artiste_id { get; set; }
    }
}