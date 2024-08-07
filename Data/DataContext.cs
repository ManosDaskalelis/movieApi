using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 5, Title = "Product 1", Url = "10.0M" },
                new Movie { Id = 6, Title = "Product 2", Url = "20.0M" },
                new Movie { Id = 7, Title = "Product 3", Url = "30.0M" }
            );
            modelBuilder.Entity<User>().HasData(
               new User { Id = 5, Username = "test1", Password = "test" },
               new User { Id = 6, Username = "test2", Password = "test1" },
               new User { Id = 7, Username = "test3", Password = "test222" }
           );
        }

    }
}
