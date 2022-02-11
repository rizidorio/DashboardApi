using Dashboard.Domain.Dtos;
using Dashboard.Domain.Entity;
using Dashboard.Domain.Interface.Repository;
using Dashboard.Domain.Interface.Service;
using Dashboard.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Dashboard.Data.Services
{
    public class DeliveryTeamService : IDeliveryTeamService
    {
        private readonly IDeliveryTeamRepository _repository;

        public DeliveryTeamService(IDeliveryTeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseModel> Add(DeliveryTeamDto deliveryTeamDto)
        {
            try
            {
                DeliveryTeam deliveryTeam = new DeliveryTeam(deliveryTeamDto.Name, deliveryTeamDto.Description, deliveryTeamDto.LicensePlate);
                await _repository.Add(deliveryTeam);

                return new ResponseModel(200, "Time de entrega adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao adicionar time de entrega, {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int id)
        {
            try
            {
                DeliveryTeam findTeam = await _repository.GetTeam(id);

                if (findTeam != null)
                {
                    await _repository.Delete(findTeam);
                    return new ResponseModel(200, "Time de entrega removido com sucesso");
                }

                return new ResponseModel(404, "Time de entrega não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao remover time de entrega, {ex.Message}");
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
                return new ResponseModel(500, $"Erro ao listar times de entrega, {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetTeam(int id)
        {
            try
            {
                DeliveryTeam findTeam = await _repository.GetTeam(id);

                if (findTeam != null)
                    return new ResponseModel(200, findTeam);

                return new ResponseModel(404, "Time de entrega não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar time de entrega, {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(DeliveryTeamDto deliveryTeamDto)
        {
            try
            {
                DeliveryTeam findTeam = await _repository.GetTeam(deliveryTeamDto.Id);

                if (findTeam != null)
                {
                    findTeam.Update(deliveryTeamDto.Name, deliveryTeamDto.Description, deliveryTeamDto.LicensePlate);
                    await _repository.Update(findTeam);

                    return new ResponseModel(200, findTeam, "Time de entrega atualizado com sucesso");
                }

                return new ResponseModel(404, "Time de entrega não encontrado");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao atualizar time de entrega, {ex.Message}");
            }
        }
    }
}
