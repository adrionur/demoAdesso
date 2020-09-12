using DemoAdesso.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DemoAdesso.DAL
{
    public class TripContext : DbContext
    {
        public DbSet<TripPlan> TripPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<TripPlan>().ToTable("TripPlan", "test");
            modelBuilder.Entity<TripPlan>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
