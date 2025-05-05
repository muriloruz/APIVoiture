using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs;

public class CreateVendedorDto
{
    [Required(ErrorMessage = "nome is required")]
    [StringLength(70, ErrorMessage = "max chars of name is 70")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "cnpj is required")]
    [MinLength(14, ErrorMessage = "max and minimal chars of cnpj is 14")]
    [MaxLength(14, ErrorMessage = "max and minimal chars of cnpj is 14")]
    public string cnpj { get; set; }
    [Required(ErrorMessage = "nome is required")]
    public string Nome { get; set; }
    public double avaliacao { get; set; }
    public int numDeAvaliacao { get; set; }
    
    public long numCasa { get; set; }
    [Required]
    public string telefoneVend { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [StringLength(70, ErrorMessage = "max size of rua is 70")]
    [Required]
    public string complemento { get; set; }
    public string RePassword { get; set; }
    public int? EnderecoId { get; set; }
}
