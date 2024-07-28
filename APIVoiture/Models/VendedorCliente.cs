using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Models
{
    public class VendedorCliente
    {
        public int? VendedorId { get; set; }
        public int? UsuarioId { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
