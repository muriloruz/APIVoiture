using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class ReadVendedorDto
    {
       public int Id { get; set; }
        public string nomeVendedor { get; set; }
        public string cnpj { get; set; }        
        public string telefoneVend { get; set; }
        public double avaliacao { get; set; }
        public int numDeAvaliacao { get; set; }
        public ReadEnderecoDto endereco { get; set; }
    }
}
