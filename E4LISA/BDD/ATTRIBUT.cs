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
    
    public partial class ATTRIBUT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ATTRIBUT()
        {
            this.PRODUIT_ATTRIBUT = new HashSet<PRODUIT_ATTRIBUT>();
        }
    
        public long Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUIT_ATTRIBUT> PRODUIT_ATTRIBUT { get; set; }
    }
}
