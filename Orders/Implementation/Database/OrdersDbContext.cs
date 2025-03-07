using Microsoft.EntityFrameworkCore;
using Orders.Model;

namespace Orders.Implementation.Database
{
    public class OrdersDbContext(DbContextOptions<OrdersDbContext> contextOptions) : DbContext(contextOptions)
    {
        public required DbSet<Order> Orders { get; set; }
    }
}