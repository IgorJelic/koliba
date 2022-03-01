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
        [Route("api/register")]
        public IHttpActionResult RegisterUser(User user)
        {
            if (!ValidateUser(user))
            {
                return BadRequest("Invalid data..");
            }

            using(var db = new AppDbContext())
            {
                if (db.Users.Any(u => u.Username.Equals(user.Username)))
                {
                    return BadRequest("Username already exists..");
                }

                //if (db.Users.Where(u => u.Username.Equals(user.Username)).ToList().Count > 0)
                //{
                //    return BadRequest("Username already exists..");
                //}

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

            return Ok(user);
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
