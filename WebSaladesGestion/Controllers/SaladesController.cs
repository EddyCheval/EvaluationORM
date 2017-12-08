using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSaladesGestion.ViewModel;
using ORMLibrary;

namespace WebSaladesGestion.Controllers
{
    public class SaladesController : Controller
    {
        private SaladesContext db = new SaladesContext();

        // GET: Salades
        public ActionResult Index()
        {
            var salades = db.Salades.Include(s => s.Fabricant);
            return View(salades.ToList());
        }

        // GET: Salades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var SaladeViewModel = new ViewModel.SaladeViewModel
            {
                Salade = db.Salades.Include(i => i.Ingredients).First(i => i.ID == id),
            };
            //Salade salade = db.Salades.Find(id);
            if (SaladeViewModel.Salade == null)
            {
                return HttpNotFound();
            }
            var SaladesList = db.Ingredients.ToList();
            SaladeViewModel.AllIngredients = SaladesList.Select(o => new SelectListItem
            {
                Text = o.Nom,
                Value = o.Id.ToString()
            });
            
            ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom", SaladeViewModel.Salade.Fabricant.ID);
            
            return View(SaladeViewModel);
        }

        // GET: Salades/Create
        public ActionResult Create()
        {
            ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom");
            ViewBag.List = new MultiSelectList(db.Ingredients, "Id", "Nom").ToList();
            return View();
        }

        // POST: Salades/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Description,Fabricant_ID")] Salade salade)
        {
            if (ModelState.IsValid)
            {
                db.Salades.Add(salade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom", salade.Fabricant.ID);
            return View(salade);
        }

        // GET: Salades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var SaladeViewModel = new ViewModel.SaladeViewModel
            {
                Salade = db.Salades.Include(i => i.Ingredients).First(i => i.ID == id),
            };
            //Salade salade = db.Salades.Find(id);
            if (SaladeViewModel.Salade == null)
            {
                return HttpNotFound();
            }
            var SaladesList = db.Ingredients.ToList();
            SaladeViewModel.AllIngredients = SaladesList.Select(o => new SelectListItem
            {
                Text = o.Nom,
                Value = o.Id.ToString()
            });
            
            ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom", SaladeViewModel.Salade.Fabricant.ID);
            
            return View(SaladeViewModel);
        }

        // POST: Salades/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaladeViewModel SaladeView)
        {

            if (SaladeView == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



            if (ModelState.IsValid)
            {
                var Update = db.Salades
                    .Include(i => i.Ingredients).First(i => i.ID == SaladeView.Salade.ID);

                if (TryUpdateModel(Update, "Salades", new string[] { "Nom","Description", "FabricantID" }))
                {
                    var newIngredients = db.Ingredients.Where(
                        m => SaladeView.SelectedIngredients.Contains(m.Id)).ToList();
                    var updatedIngredients = new HashSet<int>(SaladeView.SelectedIngredients);
                    foreach (Ingredient Ingredient in db.Ingredients)
                    {
                        if (!updatedIngredients.Contains(Ingredient.Id))
                        {
                            Update.Ingredients.Remove(Ingredient);
                        }
                        else
                        {
                            Update.Ingredients.Add(Ingredient);
                        }
                    }

                    db.Entry(Update).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.Fabricant_ID = new SelectList(db.Fabricants, "ID", "Nom", SaladeView.Salade.Fabricant.ID);
            return View(SaladeView);
        }

        // GET: Salades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salade salade = db.Salades.Find(id);
            if (salade == null)
            {
                return HttpNotFound();
            }
            return View(salade);
        }

        // POST: Salades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salade salade = db.Salades.Find(id);
            db.Salades.Remove(salade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
