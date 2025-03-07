using Orders.Implementation.Database;
using Orders.Model;
using System.Data;

namespace Orders.Implementation.Providers
{
    public class OrdersProvider
    {
        private readonly OrdersDbContext dbContext;

        public OrdersProvider(OrdersDbContext dbContext) => this.dbContext = dbContext; 

        public async Task AddOrderAsync(Order order)
        {
            dbContext.Orders.Add(order);

            await dbContext.SaveChangesAsync();
        }

        public Order? GetOrderById(Guid id) => dbContext.Orders.Find(id);

        public IEnumerable<Order> GetOrders(int pagination, int currentPage) 
            => dbContext.Orders.Skip(pagination*currentPage).Take(pagination).ToArray();
    }
}