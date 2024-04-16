using Microsoft.EntityFrameworkCore;
using MovieApi.Configurations;
using MovieApi.Entities;
using System;

namespace MovieApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenreConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
