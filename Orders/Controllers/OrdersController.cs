using Microsoft.AspNetCore.Mvc;
using Orders.Implementation.Providers;
using Orders.Model;

namespace Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersProvider provider;

        public OrdersController(OrdersProvider provider) => this.provider = provider;

        /// <summary>
        /// Find and return <see cref="Order"/> by its <paramref name="id"/>
        /// </summary>
        /// <param name="id">Your <see cref="Order.Id"/></param>
        /// <returns><see cref="Order"/> with corresponding <paramref name="id"/> or 204NoContent if no <see cref="Order"/>s were found</returns>
        [HttpGet(nameof(GetOrderById))]
        public ActionResult GetOrderById(Guid id)
        {
            Order? order = provider.GetOrderById(id);

            return order != null ? Ok(order) : NoContent();
        }

        /// <summary>
        /// Get <see cref="Order"/>s with corresponding <paramref name="pagination"/> and <paramref name="currentPage"/>
        /// </summary>
        /// <param name="pagination">Number of items per page</param>
        /// <param name="currentPage">Current page number. Starts from 0</param>
        /// <returns>Array of <see cref="Order"/>s from <paramref name="currentPage"/> or empty array if no <see cref="Order"/>s were found</returns>
        [HttpGet(nameof(GetOrders))]
        public async Task<ActionResult> GetOrders(int pagination, int currentPage)
        {
            IEnumerable<Order> orders = await provider.GetOrdersAsync(pagination, currentPage);

            return Ok(orders);
        }

        /// <summary>
        /// Adds <see cref="Order"/> to storage. Do not pass <see cref="Order.Id"/> as it will be ingnored!
        /// </summary>
        /// <param name="order"><see cref="Order"/> to save</param>
        /// <returns><see cref="OkResult"/> if saved successfully</returns>
        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] Order order)
        {
            await provider.AddOrderAsync(order);

            return Ok();
        }
    }
}
