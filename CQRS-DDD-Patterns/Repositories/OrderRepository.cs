using CQRS_DDD_Patterns.Models;

namespace CQRS_DDD_Patterns.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(string id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task SaveAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
    public class OrderRepository
    {
        private readonly Dictionary<string, Order> _orders = new Dictionary<string, Order>();

        public async Task<Order> GetByIdAsync(string id)
        {
            _orders.TryGetValue(id, out var order);
            return await Task.FromResult(order);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await Task.FromResult(_orders.Values);
        }

        public async Task SaveAsync(Order order)
        {
            string id = Guid.NewGuid().ToString();
            order.OrderId = id;
            _orders[id] = order;
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Order order)
        {
            if (_orders.ContainsKey(order.OrderId))
            {
                _orders[order.OrderId] = order;
                await Task.CompletedTask;
            }
            else
            {
                throw new KeyNotFoundException("Order not found for update.");
            }
        }

        public async Task DeleteAsync(string id)
        {
            if (_orders.ContainsKey(id))
            {
                _orders.Remove(id);
                await Task.CompletedTask;
            }
            else
            {
                throw new KeyNotFoundException("Order not found for deletion.");
            }
        }
    }
}
