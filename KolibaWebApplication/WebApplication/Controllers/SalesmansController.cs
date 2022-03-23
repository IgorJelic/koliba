using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            IList<User> salesmans = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49693/api/getsalesmans");

                var getTask = client.GetAsync("");
                getTask.Wait();

                var getResult = getTask.Result;

                if (getResult.IsSuccessStatusCode)
                {
                    var contentTask = getResult.Content.ReadAsAsync<IList<User>>();
                    contentTask.Wait();

                    salesmans = contentTask.Result;
                }
                else if (getResult.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ViewBag.ErrorMessage = "No Salesmans, Get Some Employees!";
                }
                else
                {
                    salesmans = null;
                }
            }

            if (salesmans == null)
            {
                return View(new List<User>());
            }

            return View(salesmans);
        }
    }
}