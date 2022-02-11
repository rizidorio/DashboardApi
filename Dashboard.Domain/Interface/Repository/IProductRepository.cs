using Dashboard.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.Domain.Interface.Repository
{
    public interface IProductRepository
    {
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task Delete(Product product);
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetAll();
    }
}
