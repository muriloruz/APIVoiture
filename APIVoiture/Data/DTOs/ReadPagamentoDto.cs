namespace APIVoiture.Data.DTOs
{
    public class ReadPagamentoDto
    {
        public int Id { get; set; }
        public string TipoPagamento { get; set; }
        public DateTime DataHora { get; set; }
        public string Status { get; set; }
        public string MetodoPagamento { get; set; }
        public double PrecoPeca { get; set; }
        public int PecaId { get; set; }
        public string ClienteId { get; set; }
    }
}
