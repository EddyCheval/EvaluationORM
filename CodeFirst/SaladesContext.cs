using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class SaladesContext : DbContext
    {
        public SaladesContext()
            : base("saladesEva")    //je donne le nom de la chaine de caractères        }
        {

        }
        public virtual DbSet<Salade> Salades { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
    }
}
