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
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Vendedor> Vendedor { get; set; }
    public DbSet<ModeloCarro> ModeloCarros { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.email)
            .IsUnique();
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.CPF)
            .IsUnique();
        modelBuilder.Entity<Vendedor>()
               .HasIndex(u => u.cnpj)
               .IsUnique();
        modelBuilder.Entity<Endereco>()
                .HasIndex(u => u.CEP)
                .IsUnique();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

}
