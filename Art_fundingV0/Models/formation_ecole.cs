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
    
    public partial class formation_ecole
    {
        public long idformation_ecole { get; set; }
        public long formation_id { get; set; }
        public long ecole_id { get; set; }
        public Nullable<int> cout_de_formation { get; set; }
    
        public virtual ecole ecole { get; set; }
        public virtual fomation fomation { get; set; }
    }
}
