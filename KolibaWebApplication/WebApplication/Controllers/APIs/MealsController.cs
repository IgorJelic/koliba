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
	public class MealsController : ApiController
	{
		[Route("api/meals")]
		public IHttpActionResult GetAllMeals()
		{
			IList<Meal> meals = null;

			using (var db = new AppDbContext())
			{
				//meals = db.Meals.Select(m => new Meal() { 
				//	Id = m.Id, 
				//	Name = m.Name, 
				//	Price = m.Price, 
				//	Orders = m.Orders, 
				//	Quantity = m.Quantity })
				//	.ToList<Meal>();
				meals = db.Meals.ToList<Meal>();
			}

			if (meals.Count == 0)
			{
				return NotFound();
			}

			return Ok(meals);
		}

		[Route("api/meals/{id}")]
		public IHttpActionResult GetMeal(int id)
		{
			Meal meal = null;

			using (var db = new AppDbContext())
			{
				meal = db.Meals.Where(m => m.Id == id)
					.FirstOrDefault();
			}

			if (meal == null)
			{
				return NotFound();
			}

			return Ok(meal);
		}
	}
}
