using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using System.Threading.Tasks;

namespace Dashboard.Domain.Interface.Service
{
    public interface IProductService
    {
        Task<ResponseModel> Add(ProductDto productDto);
        Task<ResponseModel> Update(ProductDto productDto);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel> GetProduct(int id);
        Task<ResponseModel> GetAll();
    }
}
