using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Models;
using OrderManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrder(Order order)
        {
            var result = await _orderService.CreateOrders(order);
            if (result)
            {
                return Ok("Order created successfully.");
            }
            return BadRequest("Failed to create order.");

        }
        [Route("/DataManagement")]
        [HttpPost]
        public async Task<ActionResult<AnalyzedData>> DataManagement([FromBody] List<OrdersData> ordersData)
        {
            var result = await _orderService.DataManagement(ordersData);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Failure to process information.");
        }
    }
}