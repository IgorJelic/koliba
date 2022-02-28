using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Drink
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public List<Order> Orders { get; set; }

    }
}