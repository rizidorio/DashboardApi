using Dashboard.Data.Context;
using Dashboard.Domain.Entity;
using Dashboard.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Data.Repository
{
    public class ItemsOrderRepository : IItemsOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemsOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemsOrder> Add(ItemsOrder itemsOrder)
        {
            _context.Add(itemsOrder);
            await _context.SaveChangesAsync();
            return itemsOrder;
        }

        public async Task Delete(ItemsOrder itemsOrder)
        {
            _context.Remove(itemsOrder);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemsOrder>> GetAll()
        {
            return await _context.ItemsOrders.AsNoTracking().ToListAsync();
        }

        public Task<ItemsOrder> GetItem(int id)
        {
            return _context.ItemsOrders.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<ItemsOrder>> GetItems(int orderId)
        {
            return await _context.ItemsOrders.Where(x => x.OrderId.Equals(orderId)).AsNoTracking().ToListAsync();
        }

        public async Task<ItemsOrder> Update(ItemsOrder itemsOrder)
        {
            _context.Update(itemsOrder);
            await _context.SaveChangesAsync();
            return itemsOrder;
        }
    }
}
