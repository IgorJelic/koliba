using System;
using System.Collections.Generic;
using WebApplication.Models.Enums;

namespace WebApplication.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public HomeDelivery Delivery { get; set; }

        public List<MealHelper> Meals { get; set; } = new List<MealHelper>();
        public List<DrinkHelper> Drinks { get; set; } = new List<DrinkHelper>();

        public User Customer { get; set; }


    }
}