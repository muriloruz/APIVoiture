using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVoiture.Models
{
    public class VendedorCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string VendedorId { get; set; }
        public string UsuarioId { get; set; }
        public int PecaId { get; set; }

        public virtual Peca Peca { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
