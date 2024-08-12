using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Models
{
    public class ModeloCarro
    {
        /*
         +modelo : String 100
		+marca : String 50 
		+ano : int
		 valvulas : String 10
		 câmbio	: String 20
		 carroceria : String 30
		 +produto : String 35
		codProdOriginal : String 100
         */
        [Key]
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage ="modelo is required")]
        [StringLength(100, ErrorMessage = "max of modelo is 100 chars")]
        public string modelo { get; set; }
        [Required]
        [StringLength(50)]
        public string marca { get; set; }
        [Required(ErrorMessage = "ano is required")]
        //asasasbskfslkfs          
        public int ano { get; set; }
        [StringLength(10, ErrorMessage = "max of valvulas is 10 chars")]
        public string valvulas { get; set; }
        [StringLength(20, ErrorMessage = "max of cambio is 20 chars")]
        public string cambio { get; set; }
        [StringLength(35, ErrorMessage = "max of carroceria is 35 chars")]
        public string carroceria { get; set; }
        [Required(ErrorMessage ="produto is required")]
        [StringLength(35, ErrorMessage = "max of produto is 35 chars")]
        public string produto { get; set; }
        [StringLength(100, ErrorMessage = "it was detected more than 100 chars in codProdOriginal")]
        public string codProdOriginal { get; set; }


        public virtual ICollection<Peca> Pecas { get; set; }
    }

}
