using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NoodleApp.Models;

namespace NoodleApp.Controllers
{
	public class HomeController : Controller
	{
		/// <summary>
		/// home index method, changed from default to include random fortune from third party API
		/// </summary>
		/// <returns>returns user to index view with new random fortune</returns>
		public async Task<IActionResult> Index()
		{
			using (var client = new HttpClient())
			{
				// add the appropriate properties on top of the client base address.
				client.BaseAddress = new Uri("http://www.yerkee.com");

				//the .Result is important for us to extract the result of the response from the call
				var response = client.GetAsync("/api/fortune").Result;

				if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
				{

					var stringResult = await response.Content.ReadAsStringAsync();
					var obj = JsonConvert.DeserializeObject<Fortune>(stringResult);


					return View(obj);
				}
				return View();
			}
		}
	}
}
