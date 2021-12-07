using CCPolandAPI.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
