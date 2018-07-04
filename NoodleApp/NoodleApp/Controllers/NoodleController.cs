using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NoodleApp.Data;
using NoodleApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
                else
                {
                    return RedirectToAction("Exception", "Index");
                }
            }
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
                        return View(obj);
                    }
                    else
                    {
                        return RedirectToAction("Exception", "Index");
                    }
                } 
             }

                return View();
            }
        }
    }