using APIVoiture.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIVoiture.Data;


public class ApplicationUser : IdentityUser
{
    public string nome { get; set; }
}


public class UsuarioContext : IdentityDbContext<ApplicationUser>
{
    public UsuarioContext(DbContextOptions<UsuarioContext> opts)
        : base(opts)
        {
           
        }
    public DbSet<Usuario> usuarios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Vendedor> Vendedor { get; set; }
    public DbSet<VendedorCliente> VendedorClientes { get; set; }
    public DbSet<Pagamento> Pagamento { get; set; }
    public DbSet<Peca> Pecas { get; set; }
    public DbSet<Favorito> Favorito { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorito>()
            .HasKey(f => f.Id);

        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        });
        modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");

        modelBuilder.Entity<Usuario>()
        .ToTable("Usuarios");

        modelBuilder.Entity<Vendedor>()
       .ToTable("Vendedores");

        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey(r => new { r.UserId, r.RoleId });
        });

        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        });
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.CPF)
            .IsUnique();
        modelBuilder.Entity<Vendedor>()
               .HasIndex(u => u.cnpj)
               .IsUnique();
        modelBuilder.Entity<Endereco>()
                .HasIndex(u => u.CEP)
                .IsUnique();

        modelBuilder.Entity<VendedorCliente>()
       .HasKey(vc => vc.Id);

        modelBuilder.Entity<VendedorCliente>()
            .HasOne(vc => vc.Vendedor)
            .WithMany(v => v.VendedorCliente)
            .HasForeignKey(vc => vc.VendedorId);

        modelBuilder.Entity<VendedorCliente>()
            .HasOne(vc => vc.Usuario)
            .WithMany(c => c.VendedorCliente)
            .HasForeignKey(vc => vc.UsuarioId);

        modelBuilder.Entity<VendedorCliente>()
            .HasOne(vc => vc.Peca)
            .WithMany(p => p.VendedorCliente)
            .HasForeignKey(vc => vc.PecaId);

        modelBuilder.Entity<Favorito>()
            .HasIndex(f => new { f.PecaId, f.UserId})
            .IsUnique();

        modelBuilder.Entity<Favorito>()
            .HasOne(h => h.Peca)
            .WithMany(h => h.Favorito)
            .HasForeignKey(h => h.PecaId);

        modelBuilder.Entity<Favorito>()
            .HasOne(h => h.User)
            .WithMany(h => h.Favorito)
            .HasForeignKey(h => h.UserId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

}
