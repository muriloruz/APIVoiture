using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class ReadUsuarioDto
    {
        public string Id { get; set; }


        public string nome { get; set; }

        public string PhoneNumber { get; set; }
        public int Idade { get; set; }

        public string Telefone { get; set; }


        public string Role { get; set; }


        public string cpf { get; set; }



        public string UserName { get; set; }


        public string Senha { get; set; }

        public long numeroResid { get; set; }

        public ReadEnderecoDto Endereco { get; set; }

        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
