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

        public List<Meal> Meals { get; set; } = new List<Meal>();
        public List<Drink> Drinks { get; set; } = new List<Drink>();

        public User Customer { get; set; }


    }
}