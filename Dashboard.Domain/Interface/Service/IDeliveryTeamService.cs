using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using System.Threading.Tasks;

namespace Dashboard.Domain.Interface.Service
{
    public interface IDeliveryTeamService
    {
        Task<ResponseModel> Add(DeliveryTeamDto deliveryTeamDto);
        Task<ResponseModel> Update(DeliveryTeamDto deliveryTeamDto);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel> GetTeam(int id);
        Task<ResponseModel> GetAll();
    }
}
