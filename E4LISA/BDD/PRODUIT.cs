//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class PRODUIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUIT()
        {
            this.PRODUIT_ATTRIBUT = new HashSet<PRODUIT_ATTRIBUT>();
            this.ZONE = new HashSet<ZONE>();
        }
    
        public long Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long CAT_Id { get; set; }
        public string Image { get; set; }
    
        public virtual CATEGORIE CATEGORIE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUIT_ATTRIBUT> PRODUIT_ATTRIBUT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZONE> ZONE { get; set; }
    }
}
