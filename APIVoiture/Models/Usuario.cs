

using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Models;

public class Usuario
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage ="O campo nome eh obrigatorio")]
    [StringLength(70, ErrorMessage ="Nome muito grande")]
    public string nome { get; set; }
    [Range(18,120,ErrorMessage = "O usuario nao pode ter mais de 120 nem menos de 18")]
    public int idade { get; set; }
    public string telefone  { get; set; }
    [MinLength(8,ErrorMessage ="CEP menor que tamanho minimo")]
    [MaxLength(8,ErrorMessage ="CEP maior que tamanho maximo")]
    public string CEP {  get; set; }
    [MinLength(11,ErrorMessage ="Cpf Menor que 11")]
    [MaxLength(11,ErrorMessage ="Cpf Maior que 11")]
    [Required(ErrorMessage ="Cpf esta ausente")]
    public string CPF { get; set; }
    public string sexo { get; set; }
    [Required(ErrorMessage ="o campo email eh obrigatorio")]
    public string email { get; set; }
    [Required(ErrorMessage = "o campo senha eh obrigatorio")]
    public string senha { get; set; }

    
    public virtual ICollection<Vendedor> Vendedores { get; set; }

    [Required]
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }

}
