using Dashboard.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.Domain.Interface.Repository
{
    public interface IItemsOrderRepository
    {
        Task<ItemsOrder> Add(ItemsOrder itemsOrder);
        Task<ItemsOrder> Update(ItemsOrder itemsOrder);
        Task Delete(ItemsOrder itemsOrder);
        Task<ItemsOrder> GetItem(int id);
        Task<IEnumerable<ItemsOrder>> GetItems(int orderId);
        Task<IEnumerable<ItemsOrder>> GetAll();
    }
}
