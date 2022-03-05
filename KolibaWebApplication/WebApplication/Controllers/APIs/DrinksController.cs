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
    public class DrinksController : ApiController
    {

        [Route("api/drinks")]
        public HttpResponseMessage GetAllDrinks()
        {
            IList<Drink> drinks = null;

            using (var db = new AppDbContext())
            {
                drinks = db.Drinks.ToList<Drink>();
            }

            if (drinks.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No drinks found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, drinks);
        }

        [Route("api/drinks/{id}")]
        public HttpResponseMessage GetDrink(int id)
        {
            Drink drink = null;

            using (var db = new AppDbContext())
            {
                drink = db.Drinks.Where(d => d.Id == id)
                    .FirstOrDefault();
            }

            if (drink == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"No drink with id : {id}");
            }

            return Request.CreateResponse(HttpStatusCode.OK, drink);
        }
    }
}
