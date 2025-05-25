using APIVoiture.Models;
using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class ReadPecaDto
    {
        public int Id { get; set; }
        public string nomePeca { get; set; }
        public double preco { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public int qntd { get; set; }
        public string fabricante { get; set; }
        public string garantia { get; set; }
        public string VendedorNome { get; set; }
        public string VendedorEmail { get; set; }
        public string VendedorTelefone { get; set; }
        public string PagamentoStatus { get; set; }
        public ICollection<FavoritoDTO> favoritoDTOs { get; set; } 
    }
}
