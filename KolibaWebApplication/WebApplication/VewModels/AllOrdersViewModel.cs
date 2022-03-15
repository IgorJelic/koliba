using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.VewModels
{
    public class AllOrdersViewModel
    {
        public IList<Order> Orders { get; set; }
    }
}