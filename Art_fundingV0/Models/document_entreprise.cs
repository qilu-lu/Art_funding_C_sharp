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
    using System.ComponentModel.DataAnnotations;

    public partial class document_entreprise
    {
        public int iddocument_entreprise { get; set; }
        public int id_entreprise { get; set; }
        [Display(Name = "Attestation d'assurance")]
        public byte[] Attestation_assurance { get; set; }
        [Display(Name = "Extrait KBIS")]
        public byte[] Kbis { get; set; }
        [Display(Name = "Relevé d'identité bancaire")]
        public byte[] RIB { get; set; }
        [Display(Name = "Derniers statuts")]
        public byte[] Dernier_statut { get; set; }
    
        public virtual entreprise entreprise { get; set; }
    }
}
