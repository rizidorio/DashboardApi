using Dashboard.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.Domain.Interface.Repository
{
    public interface IDeliveryTeamRepository
    {
        Task<DeliveryTeam> Add(DeliveryTeam deliveryTeam);
        Task<DeliveryTeam> Update(DeliveryTeam deliveryTeam);
        Task Delete(DeliveryTeam deliveryTeam);
        Task<DeliveryTeam> GetTeam(int id);
        Task<IEnumerable<DeliveryTeam>> GetAll();
    }
}
