using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APIVoiture.Models;

public class Vendedor : IdentityUser
{
    /*
      Add-Migration "Vendedor e Endereco"
      Update-Database


	--Cliente.Cpf : String 11
	--Cliente.senha : String
	--Cliente.email : String
	--Endereco.id : int

     */
   


    [Required(ErrorMessage = "cnpj is required")]
    [MinLength(14,ErrorMessage = "max and minimal chars of cnpj is 14")]
    [MaxLength(14, ErrorMessage = "max and minimal chars of cnpj is 14")]
    public string cnpj { get; set; }
    [Required]
    public string telefoneVend { get; set; }
    public double avaliacao { get; set; }
    public int numDeAvaliacao { get; set; }

    public virtual ICollection<Peca> Pecas { get; set; }

    public virtual ICollection<VendedorCliente> VendedorCliente { get; set; } //n:n
    
    [Required]
    public int EnderecoId { set; get; } //1 : 1
    public virtual Endereco Endereco { get; set; }

    public Vendedor() : base()
    {

    }
}
