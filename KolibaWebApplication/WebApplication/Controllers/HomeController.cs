using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult Register()
        {
            ViewBag.Title = "Register Page";

            return View();
        }
    }
}
