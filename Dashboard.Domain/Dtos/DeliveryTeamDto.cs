using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.Dtos
{
    public class DeliveryTeamDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nome da equipe de entrega é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome da equipe de entrega deve ter no máximo 100 caracteres")]
        [DisplayName("Nome Equipe")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição da equipe de entrega é obrigatório")]
        [MaxLength(255, ErrorMessage = "Descrição da equipe de entrega deve ter no máximo 255 caracteres")]
        [DisplayName("Descrição Equipe")]
        public string Description { get; set; }

        [RegularExpression(@"[A-Z]{3}-[\d]{1}[A-Z0-9]{1}[\d]{2}", ErrorMessage = "Placa do veículo inválida")]
        [DisplayName("Placa do Veículo")]
        public string LicensePlate { get; set; }
    }
}
