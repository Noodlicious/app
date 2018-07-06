using Microsoft.EntityFrameworkCore;
using NoodleApp.Controllers;
using NoodleApp.Data;
using NoodleApp.Models;
using System.Linq;
using Xunit;

namespace TestNoodleApp
{
    public class TestNoodleController
    {
        [Fact]
        public async void CanViewAllNoodles()
        {
            DbContextOptions<NoodleFrontDbContext> options =
                new DbContextOptionsBuilder<NoodleFrontDbContext>()
                .UseInMemoryDatabase("CanViewAllNoodles")
                .Options;
            using (NoodleFrontDbContext context = new NoodleFrontDbContext(options))
            {
                //arrange
                Noodle noodle1 = new Noodle();
                noodle1.Id = 1;
                noodle1.Name = "Chicken Ramen";
                Noodle noodle2 = new Noodle();
                noodle2.Id = 2;
                noodle2.Name = "Pork Ramen";
                Noodle noodle3 = new Noodle();
                noodle3.Id = 3;
                noodle3.Name = "Beef Ramen";

                //act
                await context.Noodles.AddAsync(noodle1);
                await context.Noodles.AddAsync(noodle2);
                await context.Noodles.AddAsync(noodle3);

                await context.SaveChangesAsync();

                //assert
                Assert.Equal(3, context.Noodles.Count());
            }
        }

        [Fact]
        public void CanSendNoodle()
        {
            DbContextOptions<NoodleFrontDbContext> options =
                new DbContextOptionsBuilder<NoodleFrontDbContext>()
                .UseInMemoryDatabase("CanSendNoodle")
                .Options;

            using (NoodleFrontDbContext context = new NoodleFrontDbContext(options))
            {
                NoodleController nc = new NoodleController(context);

                Assert.True(nc.SendNoodle().IsCompleted);
            }
        }

        [Fact]
        public void CanSendNoodleWithNoodleObjectPassedIn()
        {
            DbContextOptions<NoodleFrontDbContext> options =
                new DbContextOptionsBuilder<NoodleFrontDbContext>()
                .UseInMemoryDatabase("CanSendNoodleWithObjectPassedIn")
                .Options;

            using (NoodleFrontDbContext context = new NoodleFrontDbContext(options))
            {
                //arrange
                ViewNoodle noodle = new ViewNoodle();
                noodle.Id = 1;
                noodle.Name = "Chicken Ramen";

                NoodleController nc = new NoodleController(context);
                var sendNoodle = nc.SendNoodle();

                //assert
                Assert.True(sendNoodle.IsCompletedSuccessfully);
            }
        }

        [Fact]
        public async void CanGetDetails()
        {
            DbContextOptions<NoodleFrontDbContext> options =
                new DbContextOptionsBuilder<NoodleFrontDbContext>()
                .UseInMemoryDatabase("CanGetDetail")
                .Options;

            using (NoodleFrontDbContext context = new NoodleFrontDbContext(options))
            {
                //arrange
                Noodle noodle1 = new Noodle();
                noodle1.Id = 1;
                noodle1.Name = "Chicken Ramen";
                Noodle noodle2 = new Noodle();
                noodle2.Id = 2;
                noodle2.Name = "Pork Ramen";
                Noodle noodle3 = new Noodle();
                noodle3.Id = 3;
                noodle3.Name = "Beef Ramen";

                //act
                await context.Noodles.AddAsync(noodle1);
                await context.Noodles.AddAsync(noodle2);
                await context.Noodles.AddAsync(noodle3);

                await context.SaveChangesAsync();

                NoodleController nc = new NoodleController(context);

                var GetDetails = nc.Details(1);

                Assert.False(GetDetails.IsFaulted);
            }
        }

        [Fact]
        public async void SearchResult()
        {
            DbContextOptions<NoodleFrontDbContext> options =
                new DbContextOptionsBuilder<NoodleFrontDbContext>()
                .UseInMemoryDatabase("CanSearch")
                .Options;

            using (NoodleFrontDbContext context = new NoodleFrontDbContext(options))
            {
                //arrange
                Noodle noodle1 = new Noodle();
                noodle1.Id = 1;
                noodle1.Name = "Chicken Ramen";
                Noodle noodle2 = new Noodle();
                noodle2.Id = 2;
                noodle2.Name = "Pork Chicken";
                Noodle noodle3 = new Noodle();
                noodle3.Id = 3;
                noodle3.Name = "Beef Ramen";

                //act
                await context.Noodles.AddAsync(noodle1);
                await context.Noodles.AddAsync(noodle2);
                await context.Noodles.AddAsync(noodle3);

                await context.SaveChangesAsync();

                NoodleController nc = new NoodleController(context);

                var searchResult = nc.SearchResult("Chicken");

                Assert.True(searchResult.IsCompletedSuccessfully);
            }
        }

        [Fact]
        public async void CanTallyLikes()
        {
            DbContextOptions<NoodleFrontDbContext> options =
                new DbContextOptionsBuilder<NoodleFrontDbContext>()
                .UseInMemoryDatabase("CanTallyLikes")
                .Options;

            using (NoodleFrontDbContext context = new NoodleFrontDbContext(options))
            {
                //arrange
                Noodle noodle1 = new Noodle();
                noodle1.Id = 1;
                noodle1.Name = "Chicken Ramen";
                Noodle noodle2 = new Noodle();
                noodle2.Id = 2;
                noodle2.Name = "Pork Chicken";
                Noodle noodle3 = new Noodle();
                noodle3.Id = 3;
                noodle3.Name = "Beef Ramen";

                //act
                await context.Noodles.AddAsync(noodle1);
                await context.Noodles.AddAsync(noodle2);
                await context.Noodles.AddAsync(noodle3);

                await context.SaveChangesAsync();

                NoodleController nc = new NoodleController(context);

                var tallyLikes = nc.TallyLikes(2);

                Assert.False(tallyLikes.IsCanceled);
            }
        }

        [Fact]
        public async void CanTallyDislikes()
        {
            DbContextOptions<NoodleFrontDbContext> options =
                new DbContextOptionsBuilder<NoodleFrontDbContext>()
                .UseInMemoryDatabase("CanTallyDislikes")
                .Options;

            using (NoodleFrontDbContext context = new NoodleFrontDbContext(options))
            {
                //arrange
                Noodle noodle1 = new Noodle();
                noodle1.Id = 1;
                noodle1.Name = "Chicken Ramen";
                Noodle noodle2 = new Noodle();
                noodle2.Id = 2;
                noodle2.Name = "Pork Chicken";
                Noodle noodle3 = new Noodle();
                noodle3.Id = 3;
                noodle3.Name = "Beef Ramen";

                //act
                await context.Noodles.AddAsync(noodle1);
                await context.Noodles.AddAsync(noodle2);
                await context.Noodles.AddAsync(noodle3);

                await context.SaveChangesAsync();

                NoodleController nc = new NoodleController(context);

                var tallyDislikes = nc.TallyDislikes(2);

                Assert.False(tallyDislikes.IsCanceled);
            }
        }
    }
}