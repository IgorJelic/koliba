using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.VewModels
{
    public class MealDrinkViewModel
    {
        public IList<Meal> Meals { get; set; }
        public IList<Drink> Drinks { get; set; }
    }
}