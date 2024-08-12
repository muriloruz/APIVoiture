

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Models;

public class Usuario : IdentityUser
{
    [Range(18,120,ErrorMessage = "O usuario nao pode ter mais de 120 nem menos de 18")]
    [Required]
    public string nome { get; set; }
    public int idade { get; set; }
    public string telefone  { get; set; }
    [MinLength(8,ErrorMessage ="CEP menor que tamanho minimo")]
    [MaxLength(8,ErrorMessage ="CEP maior que tamanho maximo")]
    public string CEP {  get; set; }
    [MinLength(11,ErrorMessage ="Cpf Menor que 11")]
    [MaxLength(11,ErrorMessage ="Cpf Maior que 11")]
    [Required(ErrorMessage ="Cpf esta ausente")]
    public string CPF { get; set; }
    [Required]
    public long numeroResid { get; set; }



    public virtual ICollection<Peca> Pecas { get; set; }
    public virtual ICollection<VendedorCliente> VendedorCliente { get; set; } //n:n
    public virtual ICollection<Pagamento> Pagamentos { get; set; }

    [Required]
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }

    public Usuario() : base() {
    }

}
