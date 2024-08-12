namespace APIVoiture.Data.DTOs
{
    public class UpdatePagamentoDto
    {
        public int Id { get; set; }
        public string TipoPagamento { get; set; }
        public DateTime DataHora { get; set; }
        public string Status { get; set; }
        public string MetodoPagamento { get; set; }
        public double PrecoPeca { get; set; }
        public int PecaId { get; set; }
        public string UsuarioId { get; set; }
    }
}
