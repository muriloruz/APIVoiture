using APIVoiture.Models;
using Microsoft.EntityFrameworkCore;

namespace APIVoiture.Data;

public class UsuarioContext : DbContext
{
    public UsuarioContext(DbContextOptions<UsuarioContext> opts)
        : base(opts)
        {
           
        }
    public DbSet<Usuario> usuarios { get; set; }
}
