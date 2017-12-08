using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMLibrary
{
    public class Salade
    {
        public Salade()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Column(TypeName ="nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        public virtual Fabricant Fabricant { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
