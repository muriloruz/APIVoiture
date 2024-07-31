using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs;

public class AuthUsuarioDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
