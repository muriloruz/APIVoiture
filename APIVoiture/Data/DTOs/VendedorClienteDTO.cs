namespace APIVoiture.Data.DTOs
{
    public class VendedorClienteDTO
    {
        public string VendedorId { get; set; }
        public int PecaId { get; set; }
        public string UsuarioId { get; set; }
        
        public ReadVendedorDto? Vendedor { get; set; }
        public ReadPecaDto? Peca { get; set; }
        public ReadUsuarioDto? Usuario { get; set; }
    }
}
