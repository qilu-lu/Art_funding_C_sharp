﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class art_fundingEntities : DbContext
    {
        public art_fundingEntities()
            : base("name=art_fundingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<artiste> artistes { get; set; }
        public virtual DbSet<boite_artiste> boite_artiste { get; set; }
        public virtual DbSet<categorie> categories { get; set; }
        public virtual DbSet<contrat_abonnement> contrat_abonnement { get; set; }
        public virtual DbSet<contrat_ecole> contrat_ecole { get; set; }
        public virtual DbSet<contrat_entreprise> contrat_entreprise { get; set; }
        public virtual DbSet<document_artiste> document_artiste { get; set; }
        public virtual DbSet<document_entreprise> document_entreprise { get; set; }
        public virtual DbSet<ecole> ecoles { get; set; }
        public virtual DbSet<entreprise> entreprises { get; set; }
        public virtual DbSet<fomation> fomations { get; set; }
        public virtual DbSet<formation_ecole> formation_ecole { get; set; }
        public virtual DbSet<photo> photos { get; set; }
        public virtual DbSet<utilisateurartiste> utilisateurartistes { get; set; }
        public virtual DbSet<utilisateurentreprise> utilisateurentreprises { get; set; }
    }
}
