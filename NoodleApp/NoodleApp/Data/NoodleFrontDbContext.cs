using Microsoft.EntityFrameworkCore;
using NoodleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoodleApp.Data
{
    public class NoodleFrontDbContext : DbContext
    {
		/// <summary>
		/// sets database context to derived class of DbContext
		/// </summary>
		/// <param name="options">Db context with base options</param>
        public NoodleFrontDbContext(DbContextOptions<NoodleFrontDbContext> options) : base(options)
        {
        }

        public DbSet<Noodle> Noodles { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}
