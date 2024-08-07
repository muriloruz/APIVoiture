using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs;

public class UpdatePecaDto
{
    public string nomePeca { get; set; }
    public double preco { get; set; }
    public string descricao { get; set; }
    public byte[] imagem { get; set; }
    public int qntd { get; set; }
    public string fabricante { get; set; }
    public string garantia { get; set; }
    public double VendedorAvaliacao { get; set; }
    public string ModeloCarroValvulas { get; set; }
    public int ModeloCarroAno { get; set; }
    public string ModeloCarroModelo { get; set; }
    public string ModeloCarroMarca { get; set; }
    public string ModeloCarroCambio { get; set; }
    public string PagamentoStatus { get; set; }
}
