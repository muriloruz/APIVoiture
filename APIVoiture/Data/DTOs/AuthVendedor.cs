using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class AuthVendedor
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
