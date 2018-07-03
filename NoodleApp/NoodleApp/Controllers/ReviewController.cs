using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoodleApp.Data;

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

			ViewData["Reviews"] = await _context.Reviews.Select(x => x.NoodleId == id)
				.ToListAsync();
			return View();
			
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name, NoodleId")]NoodleApp.Models.Review review)
		{
			
			_context.Reviews.Add(review);
			
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Home");
		}

		//read

		public async Task<IActionResult> Details(int? id)
		{
			if (id.HasValue)
			{

				return View(await _context.Reviews.Where(s => s.ID == id)
					.SingleAsync());
			}
			return View();

		}

		public async Task<IActionResult> ViewAll()
		{
			var data = await _context.Reviews.ToListAsync();

			return View(data);
		}

		//update
		[HttpGet]
		public async Task<IActionResult>Update(int? id)
		{
			if (id.HasValue)
			{
				Models.Review review = await _context.Reviews.FirstOrDefaultAsync(a => a.ID == id);
				
				return View(review);
			}
				return RedirectToAction("index", "home");
		}

		[HttpPost]
		public async Task<IActionResult> Update([Bind("ID, Name")]Models.Review review)
		{
			_context.Reviews.Update(review);

			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Home");
		}

		//delete
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
