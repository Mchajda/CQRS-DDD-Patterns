using CQRS_DDD_Patterns.Models;
using MediatR;

namespace CQRS_DDD_Patterns.Commands
{
    public class CreateOrderCommand : IRequest<string>
    {
        public string CustomerId { get; }
        public ShippingInfo ShippingInfo { get; }
        public List<OrderItem> Items { get; }

        public CreateOrderCommand(string customerId, ShippingInfo shippingInfo, List<OrderItem> items)
        {
            CustomerId = customerId;
            ShippingInfo = shippingInfo;
            Items = items;
        }
    }
}
