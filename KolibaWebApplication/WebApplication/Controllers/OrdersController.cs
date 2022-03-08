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

            if (currentUser.CurrentOrder.Meals.Count == 0 && currentUser.CurrentOrder.Drinks.Count == 0)
            {
                ViewBag.errMsg = "Korpa je trenutno prazna.";
            }


            return View(currentUser.CurrentOrder);
        }

        [HttpPost]
        [Route("addmeal")]
        public ActionResult AddMeal(Meal m)
        {
            if (Session["user"] != null)
            {
                User currentUser = Session["user"] as Models.User;
                Meal tempMeal = currentUser.CurrentOrder.Meals.Where(me => me.Id == m.Id).FirstOrDefault();

                if (tempMeal != null)
                {
                    var index = currentUser.CurrentOrder.Meals.IndexOf(tempMeal);
                    currentUser.CurrentOrder.Meals[index].Quantity += m.Quantity;
                    currentUser.CurrentOrder.Meals[index].Price += m.Price;
                }
                else
                {
                    currentUser.CurrentOrder.Meals.Add(m);
                }
                Session["user"] = currentUser;
            }
            else
            {
                return RedirectToAction("SignIn", "Home");
            }

            return null;
        }

        [HttpPost]
        [Route("orders/adddrink")]
        public ActionResult AddDrink(Drink d)
        {
            if (Session["user"] != null)
            {
                User currentUser = Session["user"] as Models.User;

                Drink tempDrink = currentUser.CurrentOrder.Drinks.Where(dr => dr.Id == d.Id).FirstOrDefault();

                if (tempDrink != null)
                {
                    var index = currentUser.CurrentOrder.Drinks.IndexOf(tempDrink);
                    currentUser.CurrentOrder.Drinks[index].Quantity += d.Quantity;
                    currentUser.CurrentOrder.Drinks[index].Price += d.Price;
                }
                else
                {
                    currentUser.CurrentOrder.Drinks.Add(d);
                }

                Session["user"] = currentUser;
            }
            else
            {
                return RedirectToAction("SignIn", "Home");
            }

            return null;
        }


        [HttpGet]
        [Route("orders/createOrder")]
        public ActionResult CreateOrder()
        {
            if (Session["user"] != null)
            {
                User currentUser = Session["user"] as Models.User;

                if (currentUser.MyOrders == null)
                {
                    currentUser.MyOrders = new List<Order>();
                }

                var currentOrder = currentUser.CurrentOrder;

                currentUser.MyOrders.Add(currentOrder);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:49693/api/createOrder/" + currentUser.Id);

                    // HTTP POST

                    var postTask = client.PostAsJsonAsync("", currentOrder);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        currentUser.CurrentOrder = new Order();
                        Session["user"] = currentUser;
                        TempData["homeMessage"] = "Narudzbina Uspela";
                        //return RedirectToAction("Index", "Home");
                        return null;
                    }
                    else
                    {
                        Session["user"] = currentUser;
                        TempData["homeMessage"] = "Narudzbina Nije Uspela";
                        //return RedirectToAction("Index", "Home");
                        return null;
                    }
                }                
            }
            else
            {
                return RedirectToAction("SignIn", "Home");
            }
        }
    }
}