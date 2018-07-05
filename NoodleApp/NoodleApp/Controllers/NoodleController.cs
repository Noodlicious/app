﻿using System;
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

		[HttpPost]
		public async Task<IActionResult> SendNoodle([Bind("Id, Name, BrandId, Flavor, Description, ImgUrl")]Noodle noodle)
		{
			
			using (var client = new HttpClient())
			{
				// add the appropriate properties on top of the client base address.
				client.BaseAddress = new Uri("https://noodliciousapi.azurewebsites.net/");
				//client.DefaultRequestHeaders.Accept.Clear();
				//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				StringContent content = new StringContent(JsonConvert.SerializeObject(noodle), Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync("api/noodle", content);

				if (response.IsSuccessStatusCode)
				{
					string data = await response.Content.ReadAsStringAsync();
					noodle = JsonConvert.DeserializeObject<Noodle>(data);
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
						return View(obj);
					}
				}	
			}
			return View();

		}
	}
}