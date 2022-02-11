using Dashboard.Data.Context;
using Dashboard.Domain.Entity;
using Dashboard.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task Delete(Order order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.Include(x => x.ItemsOrders).Include(x => x.DeliveryTeam).OrderBy(x => x.CreatedAt).ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Order> Update(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
