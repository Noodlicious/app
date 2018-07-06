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

		
		
		public async Task<IActionResult> SendNoodle()
		{

			 await _context.Noodles.Select(x => x)
				.ToListAsync();
			return View();
		}

		/// <summary>
		/// method to send new noodle data to API
		/// </summary>
		/// <param name="noodle">Noodle Object</param>
		/// <returns>view of new noodle</returns>
		/// 
		//[HttpPost]
		//public async Task<IActionResult> SendNoodle([Bind("Id, Name, BrandId, Flavor, Description, ImgUrl")]Noodle noodle)
		//{
		//	noodle.Id = 0;
		//	noodle.BrandId = 0;
		//	using (var client = new HttpClient())
		//	{
		//		// add the appropriate properties on top of the client base address.
		//		client.BaseAddress = new Uri("https://noodliciousapi.azurewebsites.net/");
		//		client.DefaultRequestHeaders.Accept.Clear();
		//		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		//		//StringContent content = new StringContent(JsonConvert.SerializeObject(noodle), Encoding.UTF8, "application/json");
		//		if (ModelState.IsValid)
		//		{
		//			HttpResponseMessage response = await client.PostAsJsonAsync("api/noodle", noodle);

		//			if (response.IsSuccessStatusCode)
		//			{
		//				string data = await response.Content.ReadAsStringAsync();
		//				noodle = JsonConvert.DeserializeObject<Noodle>(data);
		//			}
		//		}
		//	}
		//	return View(noodle);
		//}

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
		/// API request method to retrieve one noodle and display on page in a details view
		/// </summary>
		/// <param name="id"></param>
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

		public async Task<IActionResult> TallyLikes(int id)
		{

			var tallyNoodle = _context.Noodles.Find(id);
			tallyNoodle.Likes += 1;
			await _context.SaveChangesAsync();

			return RedirectToAction("Details" , new { id });
		}

		public async Task<IActionResult> TallyDislikes(int id)
		{

			var tallyNoodle = _context.Noodles.Find(id);
			tallyNoodle.Dislikes += 1;
			await _context.SaveChangesAsync();

			return RedirectToAction("Details", new { id });
		}
	}
}