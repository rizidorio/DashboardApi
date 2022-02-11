using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using System.Threading.Tasks;

namespace Dashboard.Domain.Interface.Service
{
    public interface IItemsOrderService
    {
        Task<ResponseModel> Add(ItemsOrderDto itemsOrderDto);
        Task<ResponseModel> Update(ItemsOrderDto itemsOrderDto);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel> GetItem(int id);
        Task<ResponseModel> GetItems(int orderId);
        Task<ResponseModel> GetAll();
    }
}
