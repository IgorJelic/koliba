using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            User currentUser;
            //IList<Order> orders = null;

            if (Session["user"] != null)
            {
                currentUser = Session["user"] as Models.User;
            }
            else
            {
                return RedirectToAction("SignIn", "Home");
            }

            /*using (var client = new HttpClient())
            {
                int currentUserId = currentUser.Id;

                client.BaseAddress = new Uri("http://localhost:49693/api/userorders/" + currentUserId.ToString());

                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var responseResult = responseTask.Result;

                if (responseResult.IsSuccessStatusCode)
                {
                    var readTask = responseResult.Content.ReadAsAsync<IList<Order>>();
                    readTask.Wait();

                    orders = readTask.Result;
                }
                else if (responseResult.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var readTask = responseResult.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var errMsg = readTask.Result;
                    ViewBag.errMsg = errMsg;
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }*/


            return View(currentUser.CurrentOrder);
        }

        [HttpPost]
        [Route("addmeal")]
        public ActionResult AddMeal(Meal m)
        {
            if (Session["user"] != null)
            {
                User currentUser = Session["user"] as Models.User;
                currentUser.CurrentOrder.Meals.Add(m);
                Session["user"] = currentUser;
            }
            else
            {
                return RedirectToAction("SignIn", "Home");
            }

            return null;
        }

        [Route("orders/adddrink")]
        public ActionResult AddDrink(Drink d)
        {
            if (Session["user"] != null)
            {
                User currentUser = Session["user"] as Models.User;
                currentUser.CurrentOrder.Drinks.Add(d);
                Session["user"] = currentUser;
            }
            else
            {
                return RedirectToAction("SignIn", "Home");
            }

            return null;
        }

    }
}