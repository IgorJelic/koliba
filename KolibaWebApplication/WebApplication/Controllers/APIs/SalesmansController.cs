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
    public class SalesmansController : ApiController
    {

        [HttpGet]
        [Route("api/getsalesmans")]
        public HttpResponseMessage GetAllSalesmans()
        {
            IList<User> salesmans = null;

            using (var db = new AppDbContext())
            {
                salesmans = db.Users.Where(u => u.Role == Models.Enums.Role.Salesman).ToList();
            }

            if (salesmans == null || salesmans.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No salesmans!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, salesmans);
        }

        [HttpPost]
        [Route("api/addsalesman")]
        public HttpResponseMessage AddSalesman(User salesman)
        {
            User retVal = null;

            using (var db = new AppDbContext())
            {
                retVal = db.Users.Add(salesman);

                db.SaveChanges();
            }

            if (retVal != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "New salesman added!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to add new salesman!");
            }
        }

        [HttpDelete]
        [Route("api/removesalesman/{userId}")]
        public HttpResponseMessage RemoveSalesman(int userId)
        {
            bool success = false;

            using (var db = new AppDbContext())
            {
                User temp = db.Users.FirstOrDefault(u => u.Id == userId);

                if (temp != null)
                {
                    db.Users.Remove(temp);
                    db.SaveChanges();

                    success = true;
                }
            }

            if (success)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Salesman removed!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "RemoveSalesman failed!");
            }
        }
    }
}
