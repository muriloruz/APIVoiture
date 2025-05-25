using APIVoiture.Models;

namespace APIVoiture.Data.DTOs
{
    public class ReadFavDTO
    {
        public int PecaId { get; set; }
        public string? UserId { get; set; }
        public string? VendId { get; set; }
        public ICollection<Usuario> user {  get; set; }
        public ICollection<Vendedor> vend {  get; set; }

        public ICollection<Peca> peca { get; set; }
    }
}
