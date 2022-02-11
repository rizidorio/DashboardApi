using Dashboard.Data.Utils;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.Entity;
using Dashboard.Domain.Interface.Repository;
using Dashboard.Domain.Interface.Service;
using Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseModel> Add(OrderDto orderDto)
        {
            try
            {
                Order order = new Order(orderDto.Address, orderDto.DeliveryDate, orderDto.DeliveryTeamId, orderDto.TotalValue);
                await _repository.Add(order);
                return new ResponseModel(200, "Pedido adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao adicionar pedido, {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int id)
        {
            try
            {
                Order findOrder = await _repository.GetOrder(id);

                if (findOrder != null)
                {
                    await _repository.Delete(findOrder);
                    return new ResponseModel(200, "Pedido removido com sucesso");
                }

                return new ResponseModel(404, "Pedido não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao remover pedido, {ex.Message}");
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
                return new ResponseModel(500, $"Erro ao listar pedidos, {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetAll(OrderFilterModel filter)
        {
            try
            {
                IEnumerable<Order> orders = await _repository.GetAll();

                return new ResponseModel(200, orders.Paginate(filter.PageSize, filter.Page));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar pedidos, {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetOrder(int id)
        {
            try
            {
                Order findOrder = await _repository.GetOrder(id);

                if (findOrder != null)
                    return new ResponseModel(200, findOrder);

                return new ResponseModel(404, "Pedido não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar pedido, {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(OrderDto orderDto)
        {
            try
            {
                Order findOrder = await _repository.GetOrder(orderDto.Id);

                if (findOrder != null)
                {
                    findOrder.Update(orderDto.Address, orderDto.DeliveryDate, orderDto.DeliveryTeamId, orderDto.TotalValue);

                    return new ResponseModel(200, "Pedido atualizado com sucesso");
                }

                return new ResponseModel(404, "Pedido não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar pedido, {ex.Message}");
            }
        }
    }
}
