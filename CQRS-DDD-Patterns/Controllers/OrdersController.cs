using CQRS_DDD_Patterns.Commands;
using CQRS_DDD_Patterns.QueryServices;
using CQRS_DDD_Patterns.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_DDD_Patterns.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderQueryService _orderQueryService;

        public OrdersController(IMediator mediator, IOrderQueryService orderQueryService)
        {
            _mediator = mediator;
            _orderQueryService = orderQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var order = await _orderQueryService.GetOrders();
            return order != null ? Ok(order) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(string id)
        {
            var order = await _orderQueryService.GetOrderById(id);
            return order != null ? Ok(order) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            string newOrderId = await _mediator.Send(command);
            return Ok(new { OrderId = newOrderId });
        }
    }
}
