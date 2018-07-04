using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoodleApp.Data;
using NoodleApp.Models;

namespace NoodleApp.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		private NoodleFrontDbContext _context;

		public ReviewController(NoodleFrontDbContext context)
		{
			_context = context;
		}

		//search
		//public async Task<IActionResult> SearchResult(string searchString)
		//{
		//	var review = from m in _context.Reviews
		//				   select m;

		//	if (!String.IsNullOrEmpty(searchString))
		//	{
		//		review = review.Where(s => s.Name.Contains(searchString));
		//	}

		//	return View(await review.ToListAsync());
		//}

		//create
		public async Task<IActionResult> Create(int? id)
		{
			ReviewViewModel newModel = new ReviewViewModel();
			newModel.NoodleId = id.Value;
		
			newModel.Review = new Review();


			await _context.Reviews.Select(x => x)

				.ToListAsync();
			return View(newModel);
			
		}

		/// <summary>
		/// second half of method to create a new review 
		/// </summary>
		/// <param name="file">ReviewViewModel object</param>
		/// <returns>saves entry into review database and returns to home screen</returns>
		[HttpPost]
		public async Task<IActionResult> Create(ReviewViewModel file)
		{
			file.Review.NoodleId = file.NoodleId;
			_context.Reviews.Add(file.Review);
			
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Home");
		}

		//read

		public async Task<IActionResult> Details(int? id)
		{
			if (id.HasValue)
			{

				return View(await _context.Reviews.Where(s => s.NoodleId == id)
					.SingleAsync());
			}
			return View();

		}

		public async Task<IActionResult> ViewAll()
		{
			var data = await _context.Reviews.ToListAsync();

			return View(data);
		}

		/// <summary>
		/// method to get id of review to update
		/// </summary>
		/// <param name="id">nullable integer corresponding to primary key id for review in database</param>
		/// <returns>returns review to update</returns>
		[HttpGet]
		public async Task<IActionResult>Update(int? id)
		{
			if (id.HasValue)
			{
				Models.Review review = await _context.Reviews.FirstOrDefaultAsync(a => a.NoodleId == id);
				
				return View(review);
			}
				return RedirectToAction("index", "home");
		}

		/// <summary>
		/// method to post update data from form
		/// </summary>
		/// <param name="review">review object with bound properties from form</param>
		/// <returns>saves changes to database and returns to home index</returns>
		[HttpPost]
		public async Task<IActionResult> Update([Bind("ID, Name")]Models.Review review)
		{
			_context.Reviews.Update(review);

			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// method to delete review entry from database
		/// </summary>
		/// <param name="id">nullable id corresponding to integer primary key in database</param>
		/// <returns>deletes entry from database and returns to home index</returns>
		public async Task<IActionResult>Delete(int id)
		{
			var review = await _context.Reviews.FindAsync(id);


			if (review == null)
			{
				return NotFound();
			}

			_context.Reviews.Remove(review);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}
