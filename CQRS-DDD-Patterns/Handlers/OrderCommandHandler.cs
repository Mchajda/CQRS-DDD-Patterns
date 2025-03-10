using CQRS_DDD_Patterns.Commands;
using CQRS_DDD_Patterns.Models;
using CQRS_DDD_Patterns.Repositories;
using MediatR;

namespace CQRS_DDD_Patterns.Handlers
{
    public class OrderCommandHandler : 
        IRequestHandler<CreateOrderCommand, string>,
        IRequestHandler<UpdateOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<string> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
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
