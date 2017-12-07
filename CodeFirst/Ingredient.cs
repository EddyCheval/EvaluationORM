using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Ingredient
    {
        public Ingredient()
        {
            this.Salades = new HashSet<Salade>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }
        public virtual ICollection<Salade> Salades { get; set; }

    }
}
