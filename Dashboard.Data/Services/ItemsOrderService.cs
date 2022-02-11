using Dashboard.Domain.Dtos;
using Dashboard.Domain.Entity;
using Dashboard.Domain.Interface.Repository;
using Dashboard.Domain.Interface.Service;
using Dashboard.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Dashboard.Data.Services
{
    public class ItemsOrderService : IItemsOrderService
    {
        private readonly IItemsOrderRepository _repository;

        public ItemsOrderService(IItemsOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseModel> Add(ItemsOrderDto itemsOrderDto)
        {
            try
            {
                ItemsOrder itemsOrder = new ItemsOrder(itemsOrderDto.OrderId, itemsOrderDto.ProductId, itemsOrderDto.Quantity, itemsOrderDto.TotalValue);
                await _repository.Add(itemsOrder);
                return new ResponseModel(200, "Itens do pedido adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao adicionar item do pedido, {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int id)
        {
            try
            {
                ItemsOrder findItems = await _repository.GetItem(id);

                if (findItems != null)
                {
                    await _repository.Delete(findItems);
                    return new ResponseModel(200, "Item do pedido removido com sucesso");
                }
                return new ResponseModel(404, "Item do pedido não encontrado");

            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao remover item do pedido, {ex.Message}");
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
                return new ResponseModel(500, $"Erro ao listar itens do pedido, {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetItem(int id)
        {
            try
            {
                ItemsOrder findItem = await _repository.GetItem(id);

                if (findItem != null)
                    return new ResponseModel(200, findItem);
                return new ResponseModel(404, "Item do pedido não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar item do pedido, {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetItems(int orderId)
        {
            try
            {
                return new ResponseModel(200, await _repository.GetItems(orderId));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar itens do pedido, {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(ItemsOrderDto itemsOrderDto)
        {
            try
            {
                ItemsOrder findItem = await _repository.GetItem(itemsOrderDto.Id);

                if (findItem != null)
                {
                    findItem.Update(itemsOrderDto.OrderId, itemsOrderDto.ProductId, itemsOrderDto.Quantity, itemsOrderDto.TotalValue);
                    await _repository.Update(findItem);
                    return new ResponseModel(200, "Item do pedido atualizado com sucesso");
                }

                return new ResponseModel(404, "Item do pedido não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao atualizar item do pedido, {ex.Message}");
            }
        }
    }
}
