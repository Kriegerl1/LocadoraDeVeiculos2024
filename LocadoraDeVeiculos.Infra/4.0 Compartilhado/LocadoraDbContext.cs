﻿using LocadoraDeVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraDeVeiculos.Dominio.ModuloPessoas;
using LocadoraDeVeiculos.Dominio.ModuloUsuario;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloCombustiveis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Infra.Compartilhado;

public class LocadoraDbContext : IdentityDbContext<Usuario, Perfil, int>
{
    public DbSet<Plano> Planos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Aluguel> Alugueis { get; set; }
    public DbSet<Cliente> Clientes { get;  set; }
    public DbSet<TaxaServico> Taxas { get; set; }
    public DbSet<Condutor> Condutores { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Combustivel> Combustiveis { get;  set; }
    public DbSet<GrupoVeiculos> GrupoVeiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config
            .GetConnectionString("SqlServer");

        optionsBuilder.UseSqlServer(connectionString);

        optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new MapeadorTaxas());
        //modelBuilder.ApplyConfiguration(new MapeadorPlanos());
        //modelBuilder.ApplyConfiguration(new MapeadorAlugueis());
        //modelBuilder.ApplyConfiguration(new MapeadorVeiculos());
        //modelBuilder.ApplyConfiguration(new MapeadorClientes());
        //modelBuilder.ApplyConfiguration(new MapeadorCondutores());
        //modelBuilder.ApplyConfiguration(new MapeadorFuncionario());
        //modelBuilder.ApplyConfiguration(new MapeadorGrupoVeiculos());
        var assembly = typeof(LocadoraDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}