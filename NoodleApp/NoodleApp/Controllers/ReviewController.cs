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
		//	var students = from m in _context.Reviews
		//				   select m;

		//	if (!String.IsNullOrEmpty(searchString))
		//	{
		//		students = students.Where(s => s.Name.Contains(searchString));
		//	}

		//	return View(await students.ToListAsync());
		//}

		//create
		public async Task<IActionResult> Create()
		{
			ViewData["Reviews"] = await _context.Reviews.Select(x => x)
				.ToListAsync();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name")]NoodleApp.Models.Review review)
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
		//[HttpGet]
		//public async Task<IActionResult> Update(int? id)
		//{
		//	if (id.HasValue)
		//	{
		//		Models.Student student = await _context.Students.FirstOrDefaultAsync(a => a.ID == id);
		//		return View(student);
		//	}
		//	return RedirectToAction("Index", "Home");
		//}

		//[HttpPost]
		//public async Task<IActionResult> Update([Bind("ID, Name, SpyAlias, CourseId")]Models.Student student)
		//{
		//	_context.Students.Update(student);

		//	await _context.SaveChangesAsync();

		//	return RedirectToAction("Index", "Home");
		//}

		////delete
		//public async Task<IActionResult> Delete(int id)
		//{
		//	var student = await _context.Students.FindAsync(id);


		//	if (student == null)
		//	{
		//		return NotFound();
		//	}

		//	_context.Students.Remove(student);
		//	await _context.SaveChangesAsync();

		//	return RedirectToAction("Index", "Home");
		//}
	}
}
