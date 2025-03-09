using CQRS_DDD_Patterns.Models;
using CQRS_DDD_Patterns.Repositories;

namespace CQRS_DDD_Patterns.QueryServices
{
    public interface IOrderQueryService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderById(string orderId);
    }
    public class OrderQueryService : IOrderQueryService
    {
        private readonly IOrderRepository _readRepository;

        public OrderQueryService(IOrderRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _readRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderById(string orderId)
        {
            return await _readRepository.GetByIdAsync(orderId);
        }
    }
}
