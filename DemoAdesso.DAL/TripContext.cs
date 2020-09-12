using DemoAdesso.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAdesso.DAL
{
    public class TripContext : DbContext
    {
        public DbSet<TripPlan> TripPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Data Source=tripPlan.db");
    }
}
