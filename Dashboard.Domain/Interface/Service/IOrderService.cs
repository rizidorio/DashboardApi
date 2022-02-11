using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using System.Threading.Tasks;

namespace Dashboard.Domain.Interface.Service
{
    public interface IOrderService
    {
        Task<ResponseModel> Add(OrderDto orderDto);
        Task<ResponseModel> Update(OrderDto orderDto);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel> GetOrder(int id);
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetAll(OrderFilterModel filter);
    }
}
