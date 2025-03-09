namespace CQRS_DDD_Patterns.Models
{
    public class Order
    {
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public List<OrderItem> Items { get; private set; } = new();
        public ShippingInfo ShippingInfo { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(Guid customerId, ShippingInfo shippingInfo)
        {
            OrderId = Guid.NewGuid();
            CustomerId = customerId;
            ShippingInfo = shippingInfo;
            Status = OrderStatus.Pending;
        }

        public void AddItem(Product product, int quantity)
        {
            Items.Add(new OrderItem(product, quantity));
        }

        public void CompleteOrder() => Status = OrderStatus.Completed;
    }
}
