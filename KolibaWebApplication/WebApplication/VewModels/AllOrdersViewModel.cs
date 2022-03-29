using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Models.Enums;

namespace WebApplication.VewModels
{
    public class AllOrdersViewModel
    {
        public Role MyRole { get; set; }
        public IList<Order> Orders { get; set; }

    }
}