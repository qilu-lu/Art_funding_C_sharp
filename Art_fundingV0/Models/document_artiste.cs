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

    public partial class document_artiste
    {
        public long id_document_artiste { get; set; }
        public int id_artiste { get; set; }
        public byte[] CNI { get; set; }
        [Display(Name = "Justificatif de domicile")]
        public byte[] justificatif_de_domicile { get; set; }
    
        public virtual artiste artiste { get; set; }
    }
}
