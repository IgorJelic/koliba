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
            if (!ValidateUser(salesman))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");
            }

            User tempSalesman = salesman;
            tempSalesman.Role = Models.Enums.Role.Salesman;

            using (var db = new AppDbContext())
            {
                if (db.Users.Count() != 0)
                {
                    if (db.Users.Any(u => u.Username.Equals(salesman.Username)))
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Username already exists..");
                    }
                }

                tempSalesman = db.Users.Add(tempSalesman);

                //db.Users.Add(new Models.User()
                //{
                //    FirstName = salesman.FirstName,
                //    LastName = salesman.LastName,
                //    Username = salesman.Username,
                //    Password = salesman.Password,
                //    Role = Models.Enums.Role.Salesman
                //});

                db.SaveChanges();
            }


            if (tempSalesman != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "New salesman added!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to add new salesman!");
            }

            //return Request.CreateResponse(HttpStatusCode.OK, tempSalesman);
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

        private bool ValidateUser(User u)
        {
            if (string.IsNullOrWhiteSpace(u.FirstName))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(u.LastName))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(u.Username))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(u.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
