using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Models;

/*
  - Peca ---Proxima
	*id : int -
	+nomePeca : String 150 - 
	+preco : double -
	+descricao : String 1500 -
	+imagem : byte[] -
	+qntd : int -
	+fabricante : String 85 -
	+garantia : String 45
	--Vendedor.avaliacao : double
	--ModeloCarro.valvulas : String 10
	--ModeloCarro.ano : int
	--ModeloCarro.modelo: String 100	
	--ModeloCarro.marca : String 50 
	--ModeloCarro.câmbio : String 20
	--Pagamento.id : int
	--Pagamento.status : 
 */
public class Peca
{
    [Key]
    [Required]
    public int Id { get; set; }
	[Required]
	[StringLength(150)]
    public string nomePeca {  get; set; }
	[Required]
	public double preco {  get; set; }
	[Required]
	[StringLength(1500)]
	public string descricao {  get; set; }
	[Required]
	public byte[] imagem { get; set; }
	[Required]
	public int qntd { get; set; }
	[Required]
	[StringLength(85)]
	public string fabricante { get; set; }
    [Required]
    public String garantia { get; set; }


	[Required]
	public int ModeloCarroid { get; set; }
	public virtual ModeloCarro ModeloCarro { get; set; }


    [Required]
    public int VendedorId { get; set; }
    public virtual Vendedor Vendedor { get; set; }


    public int? UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }

    public virtual ICollection<Pagamento> Pagamento { get; set; }

}
