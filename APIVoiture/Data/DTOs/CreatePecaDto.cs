using APIVoiture.Models;
using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class CreatePecaDto
    {
        public string nomePeca { get; set; }
        public double preco { get; set; }
        public string descricao { get; set; }
        public byte[] imagem { get; set; }
        public int qntd { get; set; }
        public string fabricante { get; set; }
        public string garantia { get; set; }
        public int VendedorId { get; set; }
        public int ModeloCarroid { get; set; }
    }
}
