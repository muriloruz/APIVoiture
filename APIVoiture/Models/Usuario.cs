

using APIVoiture.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Models;

public class Usuario : ApplicationUser
{
   
    
    
    
    [MinLength(11,ErrorMessage ="Cpf Menor que 11")]
    [MaxLength(11,ErrorMessage ="Cpf Maior que 11")]
    [Required(ErrorMessage ="Cpf esta ausente")]
    public string CPF { get; set; }
    [Required]
    public long numeroResid { get; set; }



    public virtual ICollection<Peca> Pecas { get; set; }
    public virtual ICollection<VendedorCliente> VendedorCliente { get; set; } //n:n
    public virtual ICollection<Pagamento> Pagamentos { get; set; }

   
    public int? EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }

    public Usuario() : base() {
    }

}
