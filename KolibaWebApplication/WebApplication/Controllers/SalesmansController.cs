using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class SalesmansController : Controller
    {
        // GET: Salesmans
        public ActionResult Index()
        {
            User currentUser = Session["user"] as User;

            if (currentUser == null)
            {
                return RedirectToAction("SignIn", "Home");
            }
            else
            {
                if (currentUser.Role != Models.Enums.Role.Administrator)
                {
                    return RedirectToAction("SignOutUser", "Home");
                }
            }



            return View();
        }
    }
}