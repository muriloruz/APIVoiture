using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Models
{
    public class VendedorCliente
    {
        public string? VendedorId { get; set; }
        public string? UsuarioId { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
