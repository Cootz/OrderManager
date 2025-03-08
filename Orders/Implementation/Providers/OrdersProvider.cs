using Microsoft.EntityFrameworkCore;
using Orders.Implementation.Database;
using Orders.Model;
using System.Data;

namespace Orders.Implementation.Providers
{
    /// <summary>
    /// Provides orders business logic
    /// </summary>
    public class OrdersProvider
    {
        private readonly OrdersDbContext dbContext;

        public OrdersProvider(OrdersDbContext dbContext) => this.dbContext = dbContext; 

        /// <summary>
        /// Adds <see cref="Order"/> to database
        /// </summary>
        /// <param name="order"><see cref="Order"/> to add</param>
        public async Task AddOrderAsync(Order order)
        {
            await dbContext.Orders.AddAsync(order);

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Finds <see cref="Order"/> by <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id of <see cref="Order"/> in database</param>
        /// <returns>Found <see cref="Order"/> or <see langword="null"/> if <see cref="Order"/> with this <paramref name="id"/> doesn't exist</returns>
        public Order? GetOrderById(Guid id) => dbContext.Orders.Find(id);

        /// <summary>
        /// Reads <see cref="Order"/>s from database using <paramref name="pagination"/> and <paramref name="index"/>
        /// </summary>
        /// <param name="pagination">Number of items per page</param>
        /// <param name="index">Current page index. Starts with 0</param>
        /// <returns>Array of <see cref="Order"/>s or empty array if no <see cref="Order"/>s were found</returns>
        public Task<Order[]> GetOrdersAsync(int pagination, int index) 
            => dbContext.Orders.Skip(pagination*index).Take(pagination).ToArrayAsync();
    }
}