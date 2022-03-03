using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication.Models;
using WebApplication.Models.DataBase;

namespace WebApplication.Controllers.APIs
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/salesmans")]
        public IHttpActionResult GetAllSalesmans()
        {
            IList<Salesman> salesmans = null;

            using (var db = new AppDbContext())
            {
                salesmans = db.Salesmans.ToList<Salesman>();
            }

            if (salesmans.Count == 0)
            {
                return NotFound();
            }

            return Ok(salesmans);
        }

        [HttpPost]
        [Route("api/signin")]
        //public HttpResponseMessage SignInUser(string username, string password)
        public HttpResponseMessage SignInUser(User u)
        {
            User currentUser = null;
            var username = u.Username;
            var password = u.Password;

            using (var db = new AppDbContext())
            {
                currentUser = db.Users.Where(cu => (cu.Username.Equals(username))).FirstOrDefault();

                if (currentUser == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no user with username: {username}");
                }

                if (!currentUser.Password.Equals(password))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Wrong password for username: {username}");
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, currentUser);
        }


        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage RegisterUser(User user)
        {
            if (!ValidateUser(user))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");
            }

            using (var db = new AppDbContext())
            {
                if (db.Users.Count() != 0)
                {
                    if (db.Users.Any(u => u.Username.Equals(user.Username)))
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Username already exists..");
                    }
                }


                db.Users.Add(new Models.User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Password = user.Password,
                    Role = Models.Enums.Role.User
                });

                db.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/registerSalesman")]
        public IHttpActionResult RegisterSalesman(User user)
        {
            if (!ValidateUser(user))
            {
                return BadRequest("Invalid data..");
            }

            using (var db = new AppDbContext())
            {
                db.Salesmans.Add(new Models.Salesman()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Password = user.Password,
                    Role = Models.Enums.Role.Salesman
                });

                db.SaveChanges();
            }

            return Ok(user);
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
