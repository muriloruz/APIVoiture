using APIVoiture.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIVoiture.Data;

public class UsuarioContext : IdentityDbContext<Usuario, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public UsuarioContext(DbContextOptions<UsuarioContext> opts)
        : base(opts)
        {
           
        }
    public DbSet<Usuario> usuarios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Vendedor> Vendedor { get; set; }
    public DbSet<ModeloCarro> ModeloCarros { get; set; }
    public DbSet<VendedorCliente> VendedorClientes { get; set; }
    public DbSet<Pagamento> Pagamento { get; set; }
    public DbSet<Peca> Pecas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Usuario>(b =>
        {
            b.HasKey(u => u.Id);
            b.ToTable("AspNetUsers");
        });

        modelBuilder.Entity<IdentityRole<int>>(b =>
        {
            b.HasKey(r => r.Id);
            b.ToTable("AspNetRoles");
        });

        modelBuilder.Entity<IdentityUserRole<int>>(b =>
        {
            b.HasKey(r => new { r.UserId, r.RoleId });
            b.ToTable("AspNetUserRoles");
        });

        modelBuilder.Entity<IdentityUserClaim<int>>(b =>
        {
            b.HasKey(c => c.Id);
            b.ToTable("AspNetUserClaims");
        });

        modelBuilder.Entity<IdentityUserLogin<int>>(b =>
        {
            b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            b.ToTable("AspNetUserLogins");
        });

        modelBuilder.Entity<IdentityRoleClaim<int>>(b =>
        {
            b.HasKey(rc => rc.Id);
            b.ToTable("AspNetRoleClaims");
        });

        modelBuilder.Entity<IdentityUserToken<int>>(b =>
        {
            b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            b.ToTable("AspNetUserTokens");
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
            .HasKey(vc => new { vc.VendedorId, vc.UsuarioId });

        modelBuilder.Entity<VendedorCliente>()
            .HasOne(vc => vc.Vendedor)
            .WithMany(v => v.VendedorCliente)
            .HasForeignKey(vc => vc.VendedorId);

        modelBuilder.Entity<VendedorCliente>()
            .HasOne(vc => vc.Usuario)
            .WithMany(c => c.VendedorCliente)
            .HasForeignKey(vc => vc.UsuarioId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

}
