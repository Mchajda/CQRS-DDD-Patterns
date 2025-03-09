using CQRS_DDD_Patterns.Models;

namespace CQRS_DDD_Patterns.Commands
{
    public class CreateOrderCommand
    {
        public Guid CustomerId { get; }
        public ShippingInfo ShippingInfo { get; }
        public List<OrderItemDto> Items { get; }

        public CreateOrderCommand(Guid customerId, ShippingInfo shippingInfo, List<OrderItemDto> items)
        {
            CustomerId = customerId;
            ShippingInfo = shippingInfo;
            Items = items;
        }
    }
}
