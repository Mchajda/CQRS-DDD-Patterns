using CQRS_DDD_Patterns.Models;
using CQRS_DDD_Patterns.Repositories;

namespace CQRS_DDD_Patterns.QueryServices
{
    public class OrderQueryService
    {
        private readonly IOrderRepository _readRepository;

        public OrderQueryService(IOrderRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Order> GetOrderById(string orderId)
        {
            return await _readRepository.GetByIdAsync(orderId);
        }
    }
}
