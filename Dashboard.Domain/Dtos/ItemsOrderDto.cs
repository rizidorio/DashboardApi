using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Domain.Dtos
{
    public class ItemsOrderDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pedido é obrigatório")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Produto é obrigatório")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor Total")]
        public decimal TotalValue { get; set; }
    }
}
