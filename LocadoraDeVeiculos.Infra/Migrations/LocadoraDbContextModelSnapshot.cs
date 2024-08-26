﻿// <auto-generated />
using System;
using LocadoraDeVeiculos.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    [DbContext(typeof(LocadoraDbContext))]
    partial class LocadoraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(18)");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("TipoPerfil")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TBCliente", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos.GrupoVeiculos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupo", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloVeiculos.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Alugado")
                        .HasColumnType("bit");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadeTanqueDeCombustivel")
                        .HasColumnType("int");

                    b.Property<int>("Combustivel")
                        .HasColumnType("int");

                    b.Property<int>("Cor")
                        .HasColumnType("int");

                    b.Property<int>("GrupoVeiculosId")
                        .HasColumnType("int");

                    b.Property<int>("Marca")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("Varchar(10)");

                    b.Property<int>("Quilometragem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("TBVeiculos", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.Plano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GrupoVeiculosId")
                        .HasColumnType("int");

                    b.Property<int?>("KmDisponivel")
                        .HasColumnType("int");

                    b.Property<decimal?>("PrecoKM")
                        .HasColumnType("decimal");

                    b.Property<int>("TipoPlano")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValorDiaria")
                        .HasColumnType("decimal");

                    b.Property<decimal?>("ValorExtrapolado")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("TBPlano", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloVeiculos.Veiculo", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany("Veiculos")
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GrupoVeiculos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.Plano", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GrupoVeiculos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos.GrupoVeiculos", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
