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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public entreprise()
        {
            this.boite_artiste = new HashSet<boite_artiste>();
            this.contrat_entreprise = new HashSet<contrat_entreprise>();
            this.contrat_entreprise1 = new HashSet<contrat_entreprise>();
            this.document_entreprise = new HashSet<document_entreprise>();
            this.utilisateurentreprises = new HashSet<utilisateurentreprise>();
        }
    
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
        public string SIRET { get; set; }
    
        public virtual artiste artiste { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<boite_artiste> boite_artiste { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contrat_entreprise> contrat_entreprise { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contrat_entreprise> contrat_entreprise1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<document_entreprise> document_entreprise { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<utilisateurentreprise> utilisateurentreprises { get; set; }
    }
}
