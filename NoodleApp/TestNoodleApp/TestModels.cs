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
    public class TestModels
    {
        [Fact]
        public void NoodleNameGetter()
        {
            Noodle noodle = new Noodle();
            noodle.Name = "Cheese Ramen";
            noodle.Flavor = "Cheese";

            noodle.Name = "Extra spicy ramen";

            Assert.Equal("Extra spicy ramen", noodle.Name);
        }

        [Fact]
        public void ReviewNameGetter()
        {
            Review review = new Review();
            review.ID = 2;
            review.Name = "CHAPAGETTI IS THE BEST";

            review.Name = "SHIN BLACK IS THE BEST NOW";

            Assert.Equal("SHIN BLACK IS THE BEST NOW", review.Name);
        }

        [Fact]
        public void GetReviewViewModelsReviewID()
        {
            ReviewViewModel reviewViewModel = new ReviewViewModel();
            reviewViewModel.NoodleId = 1;

            reviewViewModel.NoodleId = 3;

            Assert.Equal(3, reviewViewModel.NoodleId);
        }

        [Fact]
        public void ViewNoodleNameGetter()
        {
            ViewNoodle noodle = new ViewNoodle();
            noodle.Name = "Extra spicy ramen";

            noodle.Name = "Cheesiest Ramen";

            Assert.Equal("Cheesiest Ramen", noodle.Name);
        }
    }
}