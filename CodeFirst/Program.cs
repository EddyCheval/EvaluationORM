using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SaladesContext())
            {
                if(!db.Salades.Any(s=>s.Nom=="Sodebo Fraicheur&Minceur"))
                {
                    var s = new Salade()
                    {
                        Nom = "Sodebo Fraicheur&Minceur",
                        Description = "Une super bonne salade"
                    };

                    db.Salades.Add(s);
                    db.SaveChanges();
                    Console.WriteLine("La Salade est créée :)");
                }
            }
        }
    }
}
