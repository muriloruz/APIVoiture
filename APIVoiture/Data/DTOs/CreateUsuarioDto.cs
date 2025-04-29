using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs;

public class CreateUsuarioDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(70, ErrorMessage = "O Nome não pode ter mais de 70 caracteres.")]
    public string Nome { get; set; }

    [Required]
    public string UserName { get; set; }

   
   

    

    [Required(ErrorMessage = "O campo CPF é obrigatório.")]
    [MinLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    [MaxLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    public string CPF { get; set; }


    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O Email não é válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [MinLength(6, ErrorMessage = "A Senha deve ter pelo menos 6 caracteres.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfSenha { get; set; }

    [Required]
    public long numeroResid { get; set; }
    public int PecaId { get; set; }
    public int? EnderecoId { get; set; }
    
}