using Microsoft.AspNetCore.Mvc;
using Orders.Implementation.Providers;
using Orders.Model;
using System.Data;

namespace Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersProvider provider;

        public OrdersController(OrdersProvider provider) => this.provider = provider;

        [HttpGet(nameof(GetOrderById))]
        public ActionResult GetOrderById(Guid id)
        {
            Order? order = provider.GetOrderById(id);

            return order != null ? Ok(order) : NotFound();
        }

        [HttpGet(nameof(GetOrders))]
        public ActionResult GetOrders(int pagination, int currentPage)
        {
            IEnumerable<Order> orders = provider.GetOrders(pagination, currentPage);

            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] Order order)
        {
            await provider.AddOrderAsync(order);

            return Ok();
        }
    }
}
