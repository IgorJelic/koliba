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
        [Route("api/orders")]
        public HttpResponseMessage GetAllOrders()
        {
            ICollection<Order> allOrders = null;

            using (var db = new AppDbContext())
            {
                //allOrders = db.Orders.Include("OrderedMeals").Include("OrderedDrinks").ToList<Order>();
                allOrders = db.Orders.Include("OrderedMeals").Include("OrderedDrinks").ToList<Order>();
            }

            if (allOrders.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No orders.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, allOrders);
        }

        [Route("api/orders/{orderId}")]
        public HttpResponseMessage GetOrder(int orderId)
        {
            Order order = null;

            using (var db = new AppDbContext())
            {
                order = db.Orders.Include("OrderedMeals").Include("OrderedDrinks").FirstOrDefault(o => o.Id == orderId);
            }

            if (order == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"No order with ID : {orderId}.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, order);
        }

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

        [HttpPost]
        [Route("api/createorder/{userId}")]
        public HttpResponseMessage CreateOrder(int userId, Order order)
        {

            using (var db = new AppDbContext())
            {
                var currentUser = db.Users.SingleOrDefault(u => u.Id == userId);
                //var currentUser = db.Users.Include("MyOrders").SingleOrDefault(u => u.Id == userId);

                if (currentUser != null)
                {
                    if (currentUser.MyOrders == null)
                    {
                        currentUser.MyOrders = new List<Order>();
                    }

                    order.CustomerId = userId;
                    db.Orders.Add(order);
                    
                    currentUser.MyOrders.Add(order);

                    db.SaveChanges();
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, $"Korisnik userId: {userId} ne postoji.");
                }

                
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
