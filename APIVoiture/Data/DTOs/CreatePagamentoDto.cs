using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class CreatePagamentoDto
    {
        [Required]
        [StringLength(25)]

        public string TipoPagamento { get; set; }

        [Required]
        public DateTime DataHora { get; set; }
        [Required]
        [StringLength(55)]
        public string Status { get; set; }
        [Required]
        [StringLength(20)]
        public string MetodoPagamento { get; set; }
        [Required]
        public double PrecoPeca { get; set; }
        [Required]
        public int PecaId { get; set; }
        [Required]
        public string UsuarioId { get; set; }
    }
}

