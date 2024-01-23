using Microsoft.EntityFrameworkCore;

using test_task.Models;

namespace test_task.Context
{
    public class OrderContext : DbContext
    {
        public DbSet<OrderViewModel> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=orders.db");
        }
    }
}
