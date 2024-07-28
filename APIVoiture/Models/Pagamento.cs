using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Models
{
    public class Pagamento
    {
        [Key]
        [Required]
        public int Id { get; set; }

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
        public virtual Peca Peca { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public virtual Usuario Cliente { get; set; }

    }
}
