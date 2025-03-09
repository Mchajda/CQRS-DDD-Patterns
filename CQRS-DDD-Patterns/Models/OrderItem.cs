namespace CQRS_DDD_Patterns.Models
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
