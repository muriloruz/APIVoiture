using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class CreateMCDto
    {
        [Required(ErrorMessage = "modelo is required")]
        [StringLength(100, ErrorMessage = "max of modelo is 100 chars")]
        public string modelo { get; set; }
        [Required]
        [StringLength(50)]
        public string marca { get; set; }
        [Required(ErrorMessage = "ano is required")]
        public int ano { get; set; }
        [StringLength(10, ErrorMessage = "max of valvulas is 10 chars")]
        public string valvulas { get; set; }
        [StringLength(20, ErrorMessage = "max of cambio is 20 chars")]
        public string cambio { get; set; }
        [StringLength(35, ErrorMessage = "max of carroceria is 35 chars")]
        public string carroceria { get; set; }
        [Required(ErrorMessage = "produto is required")]
        [StringLength(35, ErrorMessage = "max of produto is 35 chars")]
        public string produto { get; set; }
        [StringLength(100, ErrorMessage = "it was detected more than 100 chars in codProdOriginal")]
        public string codProdOriginal { get; set; }
    }
}
