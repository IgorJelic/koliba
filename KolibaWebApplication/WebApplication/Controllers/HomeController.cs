using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.DataBase;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult SignIn()
        {
            ViewBag.Title = "Sign In Page";

            return View();
        }

        [HttpPost]
        public ActionResult SignInUser(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49693/api/signin");

                // HTTP POST
                var postTask = client.PostAsJsonAsync("", user);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsAsync<User>();
                    content.Wait();

                    var currentUser = content.Result;
                    Session["user"] = currentUser;

                    return RedirectToAction("Index");
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var content = result.Content.ReadAsAsync<string>();
                    content.Wait();

                    var errMsg = content.Result;
                    ViewBag.errMsg = errMsg;

                    return View("SignIn");
                }
            }

            return new EmptyResult();
        }

        public ActionResult SignOutUser()
        {
            Session["user"] = null;

            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            ViewBag.Title = "Register Page";

            return View();
        }
    }
}
