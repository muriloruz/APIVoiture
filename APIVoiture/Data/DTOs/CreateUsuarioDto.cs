using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs;

public class CreateUsuarioDto
{
    [Required(ErrorMessage = "O campo Nome � obrigat�rio.")]
    [StringLength(70, ErrorMessage = "O Nome n�o pode ter mais de 70 caracteres.")]
    public string nome { get; set; }

    [Required]
    public string UserName { get; set; }

    [Range(18, 120, ErrorMessage = "A Idade deve estar entre 18 e 120 anos.")]
    public int Idade { get; set; }

    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo CEP � obrigat�rio.")]
    [MinLength(8, ErrorMessage = "O CEP deve ter exatamente 8 caracteres.")]
    [MaxLength(8, ErrorMessage = "O CEP deve ter exatamente 8 caracteres.")]
    public string CEP { get; set; }

    [Required(ErrorMessage = "O campo CPF � obrigat�rio.")]
    [MinLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    [MaxLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    public string CPF { get; set; }


    [Required(ErrorMessage = "O campo Email � obrigat�rio.")]
    [EmailAddress(ErrorMessage = "O Email n�o � v�lido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Senha � obrigat�rio.")]
    [MinLength(6, ErrorMessage = "A Senha deve ter pelo menos 6 caracteres.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfSenha { get; set; }

    [Required]
    public long numeroResid { get; set; }
    public int PecaId { get; set; }
    public int EnderecoId { get; set; }
    
}