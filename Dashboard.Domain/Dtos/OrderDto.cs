using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Domain.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [MaxLength(255, ErrorMessage = "Endereço deve ter no máximo 255 caracteres")]
        [DisplayName("Endereço")]
        public string Address { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? DeliveryTeamId { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor Total")]
        public decimal TotalValue { get; set; }

        public IEnumerable<ItemsOrderDto> ItemsOrders { get; set; }
    }
}
