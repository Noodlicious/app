using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoodleApp.Controllers;
using NoodleApp.Data;
using NoodleApp.Models;
using System;
using System.Linq;
using Xunit;

namespace TestNoodleApp
{
    public class TestHomeController
    {
        [Fact]
        public async void HomeViewShows()
        {
            HomeController hc = new HomeController();

            IActionResult result = await hc.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}