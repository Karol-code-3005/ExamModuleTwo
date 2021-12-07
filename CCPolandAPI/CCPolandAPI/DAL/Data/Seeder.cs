using CCPolandAPI.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Data
{
    public class Seeder
    {
        private readonly CCPolandDbContext _context;

        public Seeder(CCPolandDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Authors.Any())
                {
                    _context.Authors.AddRange(GetAuthors());
                    _context.SaveChanges();
                }
                if (!_context.Genres.Any())
                {
                    _context.Genres.AddRange(GetGenres());
                    _context.SaveChanges();
                }
                if (!_context.Materials.Any())
                {
                    _context.Materials.AddRange(GetMaterials());
                    _context.SaveChanges();
                }
                if (!_context.Reviews.Any())
                {
                    _context.Reviews.AddRange(GetReviews());
                    _context.SaveChanges();
                }
                if (!_context.Roles.Any())
                {
                    _context.Roles.AddRange(GetRoles());
                    _context.SaveChanges();
                }
                if (!_context.Users.Any())
                {
                    _context.Users.AddRange(GetUsers());
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            List<User> users = new()
            {
                new User()
                {
                    Login = "Admin123",
                    Password = "admin123",
                    RoleId = 1
                },
                new User()
                {
                    Login = "User123",
                    Password = "user123",
                    RoleId=2
                }
            };
            return users;
        }

        private IEnumerable<Role> GetRoles()
        {
            List<Role> roles = new()
            {
                new Role()
                {
                    Name = "Admin"
                },
                new Role()
                {
                    Name = "User"
                }
            };
            return roles;
        }

        private IEnumerable<Author> GetAuthors()
        {
            List<Author> authors = new()
            {
                new Author()
                {
                    Name = "Gracjan Roztocki",
                    AuthorDescription = "Young and talented C# programmer. Database and ORM specialist."
                },
                new Author()
                {
                    Name = "Mariusz Pudzianowski",
                    AuthorDescription = "Strong typed Java programmer. Best in backend."
                },
                new Author()
                {
                    Name = "Robert Maklowicz",
                    AuthorDescription = "Steam Python programmer. Frontend."
                },
                new Author()
                {
                    Name = "Adam Malysh",
                    AuthorDescription = "High-fly C# programmer. Fullstack"
                }
            };
            return authors;
        }

        private IEnumerable<Genre> GetGenres()
        {
            List<Genre> genres = new()
            {
                new Genre()
                {
                    Name = "Video",
                    Definition = "Video tutorial with step-by-step guidance in dedicated topic"
                },
                new Genre()
                {
                    Name = "Article",
                    Definition = "Topic explained in text form in user-friendly way with practical examples"
                },
                new Genre()
                {
                    Name = "Interactive tutorial",
                    Definition = "Tutorial with real-time excercises and validation."
                },
                new Genre()
                {
                    Name = "Microsoft Docs",
                    Definition = "Microsoft documentation with examples. Sometimes helpful - sometimes not."
                }
            };
            return genres;
        }

        private IEnumerable<Material> GetMaterials()
        {
            List<Material> materials = new()
            {
                new Material()
                {
                    Title = "Asynchronous programming - basics",
                    MaterialDescription = "Material explain basics in asynchronous programing (Tasks, async, await, threads, multithreds)",
                    Location = "www.si-szarp-korner.pl/synchronus-programing",
                    DateOfPublishing = new DateTime(2021,1,12),
                    AuthorId = 2,
                    GenreId = 2
                },
                new Material()
                {
                    Title = "Frontend - basics",
                    MaterialDescription = "Material explain basics frontend programing (css, html, js, bootstrap)",
                    Location = "www.jutub.pl/almost-real-programmer-tutorial",
                    DateOfPublishing = new DateTime(2020,11,14),
                    AuthorId = 3,
                    GenreId = 1
                },
                new Material()
                {
                    Title = "What SQL is?",
                    MaterialDescription = "Tutorial with excercise to get basic knowledge what sql is and how to construct querries.",
                    Location = "www.learn-interactive.pl/read-and-practice-sql",
                    DateOfPublishing = new DateTime(2019, 5,30),
                    AuthorId = 1,
                    GenreId = 3
                },
                new Material()
                {
                    Title = "Backend and Frontend integration in ASP .NET Core",
                    MaterialDescription = "Documentation with backend-frontend integration in ASP .NET Core. Very cool. Very easy.",
                    Location = "www.ms-docs.pl/frontend-backend-integration",
                    DateOfPublishing = new DateTime(2020, 3, 14),
                    AuthorId = 4,
                    GenreId = 4
                },
                new Material()
                {
                    Title = "Automapper-how to make your life easies",
                    MaterialDescription = "Setp-by-step how to implement and use automapper in c# apps.",
                    Location = "www.jutub.pl/automapper-goodgood",
                    DateOfPublishing = new DateTime(2020, 11, 26),
                    AuthorId = 4,
                    GenreId = 4
                }
            };
            return materials;
        }
        private IEnumerable<Review> GetReviews()
        {
            List<Review> reviews = new()
            {
                new Review()
                {
                    Text ="Good article i know everything",
                    Rating = 7,
                    MaterialId = 1, 
                },
                new Review()
                {
                    Text = "Excellent video, nice accent, good examples!",
                    Rating = 10,
                    MaterialId = 4,
                },
                new Review()
                {
                    Text = "I dont understand a word",
                    Rating = 2,
                    MaterialId = 4,
                },
                new Review()
                {
                    Text = "Not bad but not very good... need more examples",
                    Rating = 5,
                    MaterialId = 2,
                },
                new Review()
                {
                    Text = "Thnak you very much. Now I can pass my exam!",
                    Rating = 9,
                    MaterialId = 3,
                }
            };
            return reviews;
        }
    }
}
