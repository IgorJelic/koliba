using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Meal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public List<Order> Orders { get; set; }


        public decimal CalculatePrice()
        {
            return Price * Quantity / 1000;
        }
    }
}