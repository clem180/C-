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
    
    public partial class MAGASIN
    {
        public long ENT_Id { get; set; }
        public long Code { get; set; }
        public long Id { get; set; }
    
        public virtual ENTITE ENTITE { get; set; }
    }
}
