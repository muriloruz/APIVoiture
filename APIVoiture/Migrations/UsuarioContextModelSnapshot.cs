﻿// <auto-generated />
using System;
using APIVoiture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIVoiture.Migrations
{
    [DbContext(typeof(UsuarioContext))]
    partial class UsuarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APIVoiture.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers", (string)null);
                });

            modelBuilder.Entity("APIVoiture.Models.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("varchar(65)");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("varchar(65)");

                    b.Property<string>("uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("id");

                    b.HasIndex("CEP");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("APIVoiture.Models.Favorito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PecaId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("PecaId", "UserId")
                        .IsUnique();

                    b.ToTable("Favorito");
                });

            modelBuilder.Entity("APIVoiture.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClienteId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MetodoPagamento")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("PecaId")
                        .HasColumnType("int");

                    b.Property<double>("PrecoPeca")
                        .HasColumnType("double");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.Property<string>("TipoPagamento")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PecaId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("APIVoiture.Models.Peca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("VendedorId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("varchar(1500)");

                    b.Property<string>("fabricante")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("garantia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("imagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nomePeca")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<double>("preco")
                        .HasColumnType("double");

                    b.Property<int>("qntd")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Pecas");
                });

            modelBuilder.Entity("APIVoiture.Models.VendedorCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PecaId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("VendedorId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PecaId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VendedorId");

                    b.ToTable("VendedorClientes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("APIVoiture.Models.Usuario", b =>
                {
                    b.HasBaseType("APIVoiture.Data.ApplicationUser");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<long>("numeroResid")
                        .HasColumnType("bigint");

                    b.Property<string>("unidade")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("EnderecoId");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("APIVoiture.Models.Vendedor", b =>
                {
                    b.HasBaseType("APIVoiture.Data.ApplicationUser");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RePassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("avaliacao")
                        .HasColumnType("double");

                    b.Property<string>("cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("numCasa")
                        .HasColumnType("bigint");

                    b.Property<int>("numDeAvaliacao")
                        .HasColumnType("int");

                    b.Property<string>("telefoneVend")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.HasIndex("cnpj")
                        .IsUnique();

                    b.ToTable("Vendedores", (string)null);
                });

            modelBuilder.Entity("APIVoiture.Models.Favorito", b =>
                {
                    b.HasOne("APIVoiture.Models.Peca", "Peca")
                        .WithMany("Favorito")
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIVoiture.Models.Usuario", "User")
                        .WithMany("Favorito")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peca");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APIVoiture.Models.Pagamento", b =>
                {
                    b.HasOne("APIVoiture.Models.Usuario", "Cliente")
                        .WithMany("Pagamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIVoiture.Models.Peca", "Peca")
                        .WithMany("Pagamento")
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Peca");
                });

            modelBuilder.Entity("APIVoiture.Models.Peca", b =>
                {
                    b.HasOne("APIVoiture.Models.Usuario", "Usuario")
                        .WithMany("Pecas")
                        .HasForeignKey("UsuarioId");

                    b.HasOne("APIVoiture.Models.Vendedor", "Vendedor")
                        .WithMany("Pecas")
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("APIVoiture.Models.VendedorCliente", b =>
                {
                    b.HasOne("APIVoiture.Models.Peca", "Peca")
                        .WithMany("VendedorCliente")
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIVoiture.Models.Usuario", "Usuario")
                        .WithMany("VendedorCliente")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIVoiture.Models.Vendedor", "Vendedor")
                        .WithMany("VendedorCliente")
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peca");

                    b.Navigation("Usuario");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("APIVoiture.Models.Usuario", b =>
                {
                    b.HasOne("APIVoiture.Models.Endereco", "Endereco")
                        .WithMany("Usuario")
                        .HasForeignKey("EnderecoId");

                    b.HasOne("APIVoiture.Data.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("APIVoiture.Models.Usuario", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("APIVoiture.Models.Vendedor", b =>
                {
                    b.HasOne("APIVoiture.Models.Endereco", "Endereco")
                        .WithOne("Vendedor")
                        .HasForeignKey("APIVoiture.Models.Vendedor", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIVoiture.Data.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("APIVoiture.Models.Vendedor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("APIVoiture.Models.Endereco", b =>
                {
                    b.Navigation("Usuario");

                    b.Navigation("Vendedor")
                        .IsRequired();
                });

            modelBuilder.Entity("APIVoiture.Models.Peca", b =>
                {
                    b.Navigation("Favorito");

                    b.Navigation("Pagamento");

                    b.Navigation("VendedorCliente");
                });

            modelBuilder.Entity("APIVoiture.Models.Usuario", b =>
                {
                    b.Navigation("Favorito");

                    b.Navigation("Pagamentos");

                    b.Navigation("Pecas");

                    b.Navigation("VendedorCliente");
                });

            modelBuilder.Entity("APIVoiture.Models.Vendedor", b =>
                {
                    b.Navigation("Pecas");

                    b.Navigation("VendedorCliente");
                });
#pragma warning restore 612, 618
        }
    }
}
