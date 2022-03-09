using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication.Models.Enums;

namespace WebApplication.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public HomeDelivery Delivery { get; set; }

        public Delivered Delivered { get; set; }

        public List<MealHelper> OrderedMeals { get; set; } = new List<MealHelper>();
        public List<DrinkHelper> OrderedDrinks { get; set; } = new List<DrinkHelper>();

        
        public int CustomerId { get; set; }
        public User Customer { get; set; }

        public decimal SumPrice()
        {
            decimal sum = 0;

            if (OrderedMeals != null && OrderedMeals.Count > 0)
            {
                foreach (var m in OrderedMeals)
                {
                    sum += m.Price;
                }
            }
            if (OrderedDrinks != null && OrderedDrinks.Count > 0)
            {
                foreach (var d in OrderedDrinks)
                {
                    sum += d.Price;
                }
            }

            return sum;
        }
    }
}