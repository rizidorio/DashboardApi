using Dashboard.Domain.Dtos;
using Dashboard.Domain.Entity;
using Dashboard.Domain.Interface.Repository;
using Dashboard.Domain.Interface.Service;
using Dashboard.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Dashboard.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseModel> Add(ProductDto productDto)
        {
            try
            {
                Product product = new Product(productDto.Name, productDto.Description, productDto.Value);
                await _repository.Add(product);
                return new ResponseModel(200, "Produto adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao adicionar produto, {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int id)
        {
            try
            {
                Product findProduct = await _repository.GetProduct(id);

                if (findProduct != null)
                {
                    await _repository.Delete(findProduct);
                    return new ResponseModel(200, "Produto removido com sucesso");
                }

                return new ResponseModel(404, "Produto não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao remover produto, {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetAll()
        {
            try
            {
                return new ResponseModel(200, await _repository.GetAll());
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar produto, {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetProduct(int id)
        {
            try
            {
                Product findProduct = await _repository.GetProduct(id);

                if (findProduct != null)
                    return new ResponseModel(200, findProduct);

                return new ResponseModel(404, "Produto não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar produto, {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(ProductDto productDto)
        {
            try
            {
                Product findProduct = await _repository.GetProduct(productDto.Id);

                if (findProduct != null)
                {
                    findProduct.Update(productDto.Name, productDto.Description, productDto.Value);
                    await _repository.Update(findProduct);
                    return new ResponseModel(200, "Produto atualizado com sucesso");
                }
                return new ResponseModel(404, "Produto não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao atualizar produto, {ex.Message}");
            }
        }
    }
}
