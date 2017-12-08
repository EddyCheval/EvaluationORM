using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORMLibrary;

namespace WebSaladesGestion.ViewModel
{
    public class SaladeViewModel
    {
        public Salade Salade { get; set; }

        public IEnumerable<SelectListItem> AllIngredients { get; set; }

        private List<int> _selectedIngredients;
        public List<int> SelectedIngredients
        {
            get
            {
                if (_selectedIngredients == null)
                {
                    _selectedIngredients = Salade.Ingredients.Select(m => m.Id).ToList();
                }
                return _selectedIngredients;
            }
            set { _selectedIngredients = value; }
        }
        }
}