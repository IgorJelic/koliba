using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication.Models.Enums;

namespace WebApplication.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Role Role { get; set; }

        public List<Order> MyOrders { get; set; }

        [NotMapped]
        public Order CurrentOrder { get; set; }

        public User()
        {
            CurrentOrder = new Order();
        }
    }
}