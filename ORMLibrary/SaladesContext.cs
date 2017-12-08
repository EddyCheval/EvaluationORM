using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMLibrary
{
    public class SaladesContext : DbContext
    {
        public SaladesContext()
            : base("saladesEva")    //je donne le nom de la chaine de caractères        }
        {

        }

        public virtual DbSet<Fabricant> Fabricants { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Salade> Salades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salade>()
            .HasMany(p => p.Ingredients)
            .WithMany(r => r.Salades)
            .Map(mc =>
            {
                mc.MapLeftKey("Salade_ID");
                mc.MapRightKey("Ingredient_Id");
                mc.ToTable("SaladeIngredients");
            });
        }

    }
}
