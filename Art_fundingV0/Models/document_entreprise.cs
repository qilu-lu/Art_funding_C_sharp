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
    
    public partial class document_entreprise
    {
        public int iddocument_entreprise { get; set; }
        public int id_entreprise { get; set; }
        public byte[] Attestation_assurance { get; set; }
        public byte[] Kbis { get; set; }
        public byte[] RIB { get; set; }
        public byte[] Dernier_statut { get; set; }
    
        public virtual entreprise entreprise { get; set; }
    }
}
