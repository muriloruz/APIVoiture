using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs;

public class UpdateUsuarioDto
{
    
    public string UserName { get; set; }
    
    public string CPF { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public string nome { get; set; }

    public string? Password { get; set; }

    public long Complemento { get; set; }
    public long numeroResid { get; set; }

    public int? EnderecoId { get; set; }
}