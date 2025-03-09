using CQRS_DDD_Patterns.Commands;
using CQRS_DDD_Patterns.Models;
using CQRS_DDD_Patterns.Repositories;
using MediatR;

namespace CQRS_DDD_Patterns.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        async Task<string> IRequestHandler<CreateOrderCommand, string>.Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order(command.CustomerId, command.ShippingInfo);
            foreach (var item in command.Items)
            {
                order.AddItem(item.Product, item.Quantity);
            }
            await _orderRepository.SaveAsync(order);

            return order.OrderId;
        }
    }
}
