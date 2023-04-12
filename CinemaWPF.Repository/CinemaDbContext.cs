using CinemaWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaWPF.Repository
{
    public partial class CinemaDbContext : DbContext
    {
        public virtual DbSet<Reserve> Owners { get; set; }

        public CinemaDbContext()
        {
            this.Database.EnsureCreated();
        }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("CinemaDatabase").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserve>().HasData(
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve(),
                new Reserve()
            );
        }
    }
}
