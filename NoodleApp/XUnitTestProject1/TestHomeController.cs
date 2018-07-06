using Microsoft.AspNetCore.Mvc;
using NoodleApp.Controllers;
using System;
using Xunit;

namespace NoodleAppTests
{
    public class TestHomeController
    {
        [Fact]
        public void HomeViewShows()
        {
            TestHomeController hc = new HomeController();

            IActionResult result = hc.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}