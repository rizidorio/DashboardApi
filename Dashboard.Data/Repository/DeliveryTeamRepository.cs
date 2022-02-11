using Dashboard.Data.Context;
using Dashboard.Domain.Entity;
using Dashboard.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Data.Repository
{
    public class DeliveryTeamRepository : IDeliveryTeamRepository
    {
        private readonly ApplicationDbContext _context;

        public DeliveryTeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeliveryTeam> Add(DeliveryTeam deliveryTeam)
        {
            DeliveryTeam findTeam = _context.DeliveryTeams.FirstOrDefault(x => x.Name.Equals(deliveryTeam.Name));

            if (findTeam == null)
            {
                _context.Add(deliveryTeam);
                await _context.SaveChangesAsync();

                return deliveryTeam;
            }

            throw new Exception("Já existe um time de entrega com esse nome");
        }

        public async Task Delete(DeliveryTeam deliveryTeam)
        {
            _context.Remove(deliveryTeam);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DeliveryTeam>> GetAll()
        {
            return await _context.DeliveryTeams.AsNoTracking().ToListAsync();
        }

        public async Task<DeliveryTeam> GetTeam(int id)
        {
            return await _context.DeliveryTeams.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<DeliveryTeam> Update(DeliveryTeam deliveryTeam)
        {
            _context.Update(deliveryTeam);
            await _context.SaveChangesAsync();

            return deliveryTeam;
        }
    }
}
