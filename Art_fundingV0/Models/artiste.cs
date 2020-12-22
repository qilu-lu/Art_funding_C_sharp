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
    
    public partial class artiste
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public artiste()
        {
            this.entreprises = new HashSet<entreprise>();
            this.utilisateurartistes = new HashSet<utilisateurartiste>();
        }
    
        public int idartiste { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public System.DateTime date_de_naissance { get; set; }
        public string adresse { get; set; }
        public string code_postale { get; set; }
        public string ville { get; set; }
        public string pays { get; set; }
        public string mail { get; set; }
        public string numero { get; set; }
        public int projet_id { get; set; }
        public string description { get; set; }
        public long ecole_choisie_id { get; set; }
        public Nullable<int> formation_choisie_id { get; set; }
        public string mot_de_passe { get; set; }
        public Nullable<System.DateTime> Disponibilite { get; set; }
        public int categorie_id { get; set; }
    
        public virtual ecole ecole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<entreprise> entreprises { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<utilisateurartiste> utilisateurartistes { get; set; }
    }
}
