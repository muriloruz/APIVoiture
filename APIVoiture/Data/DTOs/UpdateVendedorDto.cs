using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class UpdateVendedorDto
    {
        [Required(ErrorMessage = "nome is required")]
        [StringLength(70, ErrorMessage = "max chars of name is 70")]
        public string nome { get; set; }
        public string userName { get; set; }
        [Required(ErrorMessage = "cnpj is required")]
        [MinLength(14, ErrorMessage = "max and minimal chars of cnpj is 14")]
        [MaxLength(14, ErrorMessage = "max and minimal chars of cnpj is 14")]
        public string cnpj { get; set; }
        public string telefoneVend { get; set; }
        public double avaliacao { get; set; }
        public int numDeAvaliacao { get; set; }
        [Required]
        public long numCasa { get; set; }
        public string complemento { get; set; }
        public int? EnderecoId { get; set; }
    }
}
