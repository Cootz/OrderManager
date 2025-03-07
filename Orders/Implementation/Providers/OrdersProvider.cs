using Orders.Model;

namespace Orders.Implementation.Providers
{
    public class OrdersProvider
    {
        public async Task AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders(int pagination, int currentPage)
        {
            throw new NotImplementedException();
        }
    }
}