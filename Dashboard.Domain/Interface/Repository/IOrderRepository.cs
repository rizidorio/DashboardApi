using Dashboard.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.Domain.Interface.Repository
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order order);
        Task<Order> Update(Order order);
        Task Delete(Order order);
        Task<Order> GetOrder(int id);
        Task<IEnumerable<Order>> GetAll();
    }
}
