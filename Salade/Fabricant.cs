using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Salade
{

    public partial class Fabricant
    {
        public Fabricant()
        {
            this.Salades = new HashSet<Salade>();
        }

        [Key]
        public int ID { get; set; }

        [StringLength(30)]
        public string Nom { get; set; }
    
        public virtual ICollection<Salade> Salades { get; set; }
    }
}
