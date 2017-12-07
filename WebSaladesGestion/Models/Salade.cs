//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSaladesGestion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Salade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Salade()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }
    
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public Nullable<int> Fabricant_ID { get; set; }
    
        public virtual Fabricant Fabricant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
