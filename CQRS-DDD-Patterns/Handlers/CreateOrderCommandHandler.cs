using CQRS_DDD_Patterns.Commands;
using CQRS_DDD_Patterns.Models;
using CQRS_DDD_Patterns.Repositories;

namespace CQRS_DDD_Patterns.Handlers
{
    public class CreateOrderCommandHandler
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(CreateOrderCommand command)
        {
            var order = new Order(command.CustomerId, command.ShippingInfo);
            foreach (var item in command.Items)
            {
                order.AddItem(item.Product, item.Quantity);
            }
            await _orderRepository.SaveAsync(order);
        }
    }
}
