using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NoodleApp.Data;
using NoodleApp.Models;

namespace NoodleApp.Controllers
{
    public class NoodleController : Controller
    {

		private NoodleFrontDbContext _context;

		public NoodleController(NoodleFrontDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> ViewAllNoodles()
        {
            using (var client = new HttpClient())
            {
                // add the appropriate properties on top of the client base address.
                client.BaseAddress = new Uri("https://noodliciousapi.azurewebsites.net/");

                //the .Result is important for us to extract the result of the response from the call
                var response = client.GetAsync("/api/noodle").Result;

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {

                    var stringResult = await response.Content.ReadAsStringAsync();
					var obj = JsonConvert.DeserializeObject<List<Noodle>>(stringResult);

                    return View(obj);
                }
              
            }
			return View();
		}

		public async Task<IActionResult> Create()
		{

			ViewData["Noodles"] = await _context.Noodles.Select(x => x)
				.ToListAsync();
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Id, Name, Country, Brand, Flavor, ImgUrl, Description")]NoodleApp.Models.Noodle noodle)
		{

			_context.Noodles.Add(noodle);

			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Home");
		}


		public async Task<IActionResult> Details(int? id)
		{
			if (id.HasValue)
			{

				using (var client = new HttpClient())
				{
					// add the appropriate properties on top of the client base address.
					client.BaseAddress = new Uri("https://noodliciousapi.azurewebsites.net/");

					//the .Result is important for us to extract the result of the response from the call
					var response = client.GetAsync($"/api/noodle/{id}").Result;

					if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
					{
						var stringResult = await response.Content.ReadAsStringAsync();
						var obj = JsonConvert.DeserializeObject<Noodle>(stringResult);
						var reviewsForThisNoodle = await _context.Reviews.Where(x => x.NoodleId == id).ToListAsync();
						
						return View(obj);
					}
				}	
			}
			return View();

		}
	}
}