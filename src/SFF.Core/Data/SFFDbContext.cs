using System;
using Microsoft.EntityFrameworkCore;
using SFF.Core.Entities;

namespace SFF.Core.Data
{
    public class SFFDbContext : DbContext
    {
        public SFFDbContext(DbContextOptions<SFFDbContext> options) : base(options)
        {
        }

        public DbSet<Association> Associations { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Lending> Lendings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lending>().HasOne(p => p.Association);
            modelBuilder.Entity<Lending>().HasOne(p => p.Movie);
            modelBuilder.Entity<Lending>(e => e.Property(p => p.Returned).HasDefaultValue(false));
            modelBuilder.Entity<Lending>(e => e.Property(p => p.LendingDate).HasDefaultValue(DateTime.Now));
            modelBuilder.Entity<Review>().HasOne(p => p.Association);
            modelBuilder.Entity<Review>().HasOne(p => p.Movie);
        }
    }
}