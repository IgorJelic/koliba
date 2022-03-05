using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;
using WebApplication.Models.DataBase;

namespace WebApplication.Controllers.APIs
{
    public class OrdersController : ApiController
    {
        [Route("api/userorders/{userId}")]
        public HttpResponseMessage GetUserOrders(int userId)
        {
            IList<Order> userOrders = null;

            using (var db = new AppDbContext())
            {
                userOrders = db.Orders.Where(o => o.Customer.Id == userId).ToList<Order>();
            }

            if (userOrders.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customer has no orders.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, userOrders);
        }
    }
}
