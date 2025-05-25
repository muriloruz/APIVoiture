using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIVoiture.Models
{
    public class Favorito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Required]
        public int Id { get; set; }
        public int PecaId { get; set; }
        public string UserId { get; set; }
        public virtual Peca Peca { get; set; }
        public virtual Usuario User { get; set; }
    }
}