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

    public partial class entreprise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public entreprise()
        {
            this.boite_artiste = new HashSet<boite_artiste>();
            this.contrat_entreprise = new HashSet<contrat_entreprise>();
            this.document_entreprise = new HashSet<document_entreprise>();
            this.utilisateurentreprises = new HashSet<utilisateurentreprise>();
        }
    
        public int identreprise { get; set; }
        [Display(Name = "Dénomination Commerciale")]
        public string denomination_Commerciale { get; set; }
        [Display(Name = "Raison sociale")]
        public string raison_Sociale { get; set; }
        [Display(Name = "Nom de l'ayant droit")]
        public string nom_de_l_ayant_droit { get; set; }
        [Display(Name = "Prénom de l'ayant droit")]
        public string prenom_de_l_ayant_droit { get; set; }
        [Display(Name = "Fonction au sein de l'entreprise")]
        public string fonction_au_sein_de_l_entreprise { get; set; }

        [Display(Name = "Adresse")]
        public string adresse { get; set; }
        [Display(Name = "Code postale")]
        public int code_postale { get; set; }
        [Display(Name = "Ville")]
        public string ville { get; set; }
        [Display(Name = "Pays")]
        public string pays { get; set; }
        [Display(Name = "Adresse email")]
        public string adresse_email { get; set; }
        [Display(Name = "Numéro")]
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
        public virtual ICollection<document_entreprise> document_entreprise { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<utilisateurentreprise> utilisateurentreprises { get; set; }
    }
}
