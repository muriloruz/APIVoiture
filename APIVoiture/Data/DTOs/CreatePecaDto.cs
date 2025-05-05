using APIVoiture.Models;
using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class CreatePecaDto
    {
        [Required]
        public string nomePeca { get; set; }
        [Required]
        public double preco { get; set; }
        [Required]
        public string descricao { get; set; }
        public IFormFile imagem { get; set; }
        [Required]
        public int qntd { get; set; }
        [Required]
        public string fabricante { get; set; }
        [Required]
        public string garantia { get; set; }
        [Required]
        public string VendedorId { get; set; }
        
    }
}
