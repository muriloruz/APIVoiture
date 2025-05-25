using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class ReadVendedorDto
    {
       public string Id { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        
        public string complemento { get; set; }
        public long numCasa { get; set; }
        public string cnpj { get; set; }        
        public string telefoneVend { get; set; }
        public double avaliacao { get; set; }
        public int numDeAvaliacao { get; set; }
        public ReadEnderecoDto endereco { get; set; }
        public ICollection<ReadPecaDto> pecas { get; set; }
    }
}
