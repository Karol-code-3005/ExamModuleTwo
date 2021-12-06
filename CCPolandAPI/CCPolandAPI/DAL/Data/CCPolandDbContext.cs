using CCPolandAPI.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Data
{
    public class CCPolandDbContext : DbContext
    {
        public CCPolandDbContext(DbContextOptions<CCPolandDbContext> options) : base(options)
        {

        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
