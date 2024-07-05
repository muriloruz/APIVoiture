using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class ReadUsuarioDto
    {
       
        public string Nome { get; set; }

        
        public int Idade { get; set; }

        public string Telefone { get; set; }

        
        public string CEP { get; set; }

        
        public string CPF { get; set; }

        public string Sexo { get; set; }

       
        public string Email { get; set; }

        
        public string Senha { get; set; }

        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
