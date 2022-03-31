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
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Message = TempData["homeMessage"];

            if (Session["user"] != null)
            {
                var currentUser = Session["user"] as Models.User;
                return View(currentUser);
            }

            return View();
        }

        public ActionResult MyOrders()
        {
            int myId = 0;

            if (Session["user"] != null)
            {
                var currentUser = Session["user"] as Models.User;
                myId = currentUser.Id;
            }
            else
            {
                return RedirectToAction("SignIn", "Home");
            }

            IList<Order> myOrders = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://localhost:49693/api/userorders/{myId}");

                var getTask = client.GetAsync("");
                getTask.Wait();

                var getResult = getTask.Result;

                if (getResult.IsSuccessStatusCode)
                {
                    var readTask = getResult.Content.ReadAsAsync<IList<Order>>();
                    readTask.Wait();

                    myOrders = readTask.Result;
                }
                else
                {
                    myOrders = null;
                }
            }

            return View(myOrders);
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
