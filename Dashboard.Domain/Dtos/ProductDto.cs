using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Domain.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome do produto deve ter no máximo 100 caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição do produto é obrigatório")]
        [MaxLength(255, ErrorMessage = "Descrição do produto deve ter no máximo 255 caracteres")]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        public decimal Value { get; set; }
    }
}
