using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetByOrderType(string orderType);
    }
}