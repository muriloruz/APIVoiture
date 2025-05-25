using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs;

public class UpdatePecaDto
{
    public string? NomePeca { get; set; }
    public string? Descricao { get; set; }
    public string? Garantia { get; set; }
    public string? Fabricante { get; set; }
    public int? Qntd { get; set; }
    public double? Preco { get; set; } 
    public string? VendedorId { get; set; }

    public IFormFile? Imagem { get; set; }

}
