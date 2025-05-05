

namespace APIVoiture.Data.DTOs
{
    public class ReadEnderecoDto
    {
        public int id { get; set; }
        public string CEP { get; set; }
        
        public string rua { get; set; }
 
        public string bairro { get; set; }
 
        public string cidade { get; set; }
 
        
        public string complemento { get; set; }

        
        public string uf { get; set; }
    }
}
