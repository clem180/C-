﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E4LISA.BDD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LISA_DIGITALEntities : DbContext
    {
        public LISA_DIGITALEntities()
            : base("name=LISA_DIGITALEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ATTRIBUT> ATTRIBUT { get; set; }
        public virtual DbSet<CATALOGUE> CATALOGUE { get; set; }
        public virtual DbSet<CATALOGUE_ENTITE> CATALOGUE_ENTITE { get; set; }
        public virtual DbSet<CATEGORIE> CATEGORIE { get; set; }
        public virtual DbSet<ENTITE> ENTITE { get; set; }
        public virtual DbSet<MAGASIN> MAGASIN { get; set; }
        public virtual DbSet<OPERATION> OPERATION { get; set; }
        public virtual DbSet<PAGE> PAGE { get; set; }
        public virtual DbSet<PRODUIT> PRODUIT { get; set; }
        public virtual DbSet<PRODUIT_ATTRIBUT> PRODUIT_ATTRIBUT { get; set; }
        public virtual DbSet<UTILISATEUR> UTILISATEUR { get; set; }
        public virtual DbSet<ZONE> ZONE { get; set; }
    }
}
