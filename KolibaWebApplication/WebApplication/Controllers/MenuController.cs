using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.DataBase;
using WebApplication.VewModels;

namespace WebApplication.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            MealDrinkViewModel md = new MealDrinkViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49693/api/");

                var responseTask = client.GetAsync("meals");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Meal>>();
                    readTask.Wait();

                    md.Meals = readTask.Result;
                }

                responseTask = client.GetAsync("drinks");
                responseTask.Wait();

                result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Drink>>();
                    readTask.Wait(); ;

                    md.Drinks = readTask.Result;
                }

            }

            return View(md);
        }
    }
}