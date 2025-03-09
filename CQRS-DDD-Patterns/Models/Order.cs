namespace CQRS_DDD_Patterns.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public ShippingInfo ShippingInfo { get; set; }
        public OrderStatus Status { get; set; }

        public Order ()
        {

        }

        public Order(string customerId, ShippingInfo shippingInfo)
        {
            OrderId = Guid.NewGuid().ToString();
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
