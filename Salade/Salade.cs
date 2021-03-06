//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Salade
{

    public partial class Salade
    {
        public Salade()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        
        public Nullable<int> Fabricant_ID { get; set; }
        public virtual Fabricant Fabricant { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
