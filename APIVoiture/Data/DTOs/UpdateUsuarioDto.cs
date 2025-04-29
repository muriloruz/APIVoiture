using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs;

public class UpdateUsuarioDto
{
    [StringLength(70, ErrorMessage = "O Nome não pode ter mais de 70 caracteres.")]
    public string UserName { get; set; }

    

    [MinLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    [MaxLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    public string CPF { get; set; }

    

    [EmailAddress(ErrorMessage = "O Email não é válido.")]
    public string Email { get; set; }

    
    [MinLength(6, ErrorMessage = "A Senha deve ter pelo menos 6 caracteres.")]
    public string? Password { get; set; }

    
    public long numeroResid { get; set; }

    public int? EnderecoId { get; set; }
}