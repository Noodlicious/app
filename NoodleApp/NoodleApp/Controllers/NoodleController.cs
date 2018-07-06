using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

		/// <summary>
		/// method to retrieve current noodle data from api, updates server database
		/// </summary>
		/// <returns>view of current noodle list</returns>
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

					foreach (var item in obj)
					{
							Noodle alreadyExists = await _context.Noodles.FirstOrDefaultAsync(x => x.Name == item.Name);

							if(alreadyExists == null)
							{
								item.Id = null;
								_context.Noodles.Add(item);
							}
							else
							{
							if (alreadyExists.Name != item.Name) {
								item.Id = null;
								_context.Noodles.Add(item);
							}
						}
					}

					await _context.SaveChangesAsync();

					return View(obj);
                }
            }
			return View();
		}

		
		/// <summary>
		/// method to send user to create noodle form
		/// </summary>
		/// <returns>returns user to form view</returns>
		public async Task<IActionResult> SendNoodle()
		{

			 await _context.Noodles.Select(x => x)
				.ToListAsync();
			return View();
		}

		/// <summary>
		/// method to submit form information and post into API
		/// </summary>
		/// <param name="noodle">noodle object taken from form data</param>
		/// <returns>returns view with new noodle object</returns>
		[HttpPost]
		public async Task<IActionResult> SendNoodle(ViewNoodle noodle)
		{
			noodle.Id = 0;
			noodle.BrandId = 0;
			using (var client = new HttpClient())
			{
				// add the appropriate properties on top of the client base address.
				client.BaseAddress = new Uri("https://noodliciousapi.azurewebsites.net/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			
				if (ModelState.IsValid)
				{
					HttpResponseMessage response = await client.PostAsJsonAsync("api/noodle", noodle);

					if (response.IsSuccessStatusCode)
					{
						string data = await response.Content.ReadAsStringAsync();
					
					}
				}
			}
			return View(noodle);
		}

		/// <summary>
		/// API request method to retrieve one noodle and display on page in a details view, switched to do the same from server database. 
		/// </summary>
		/// <param name="id">nullable integer id received from API noodle primary key</param>
		/// <returns>object from API and displays on page</returns>
		public async Task<IActionResult> Details(int? id)
		{
			if (id.HasValue)
			{

				//using (var client = new HttpClient())
				//{
				//	// add the appropriate properties on top of the client base address.
				//	client.BaseAddress = new Uri("https://noodliciousapi.azurewebsites.net/");

				//	//the .Result is important for us to extract the result of the response from the call
				//	var response = client.GetAsync($"/api/noodle/{id}").Result;

				//	if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
				//	{
				//		var stringResult = await response.Content.ReadAsStringAsync();
				//		var obj = JsonConvert.DeserializeObject<Noodle>(stringResult);

				var foundNoodle = _context.Noodles.Find(id);
						var reviewsForThisNoodle = await _context.Reviews.Where(x => x.NoodleId == id).ToListAsync();
						
						return View(foundNoodle);
				//	}
				//}	
			}
			return View();
		}

		/// <summary>
		/// method to search noodle results
		/// </summary>
		/// <param name="searchString">user input string to search for</param>
		/// <returns>list view of noodles matching results</returns>
		public async Task<IActionResult> SearchResult(string searchString)
		{
			var noodle = from m in _context.Noodles
						   select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				noodle = noodle.Where(s => s.Name.Contains(searchString));
				
			}

			return View(await noodle.ToListAsync());
		}

		/// <summary>
		/// method to tally user likes for a particular noodle
		/// </summary>
		/// <param name="id">nullable integer id corresponding to noodle primary key</param>
		/// <returns>returns user to details view with new likes tally</returns>
		public async Task<IActionResult> TallyLikes(int id)
		{

			var tallyNoodle = _context.Noodles.Find(id);
			tallyNoodle.Likes += 1;
			await _context.SaveChangesAsync();

			return RedirectToAction("Details" , new { id });
		}

		/// <summary>
		/// method to tally user dislikes
		/// </summary>
		/// <param name="id">nullable integer id corresponding to noodle primary key</param>
		/// <returns>user to details view with dislikes updated</returns>
		public async Task<IActionResult> TallyDislikes(int id)
		{

			var tallyNoodle = _context.Noodles.Find(id);
			tallyNoodle.Dislikes += 1;
			await _context.SaveChangesAsync();

			return RedirectToAction("Details", new { id });
		}
	}
}