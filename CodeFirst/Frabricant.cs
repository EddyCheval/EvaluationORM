using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Fabricant
    {
        [Key]
        public int ID { get; set; }

        [StringLength(30)]
        public string Nom { get; set; }

        public virtual ICollection<Salade> Salades { get; set; }
    }
}
