﻿using FizzWare.NBuilder;
using LocadoraDeVeiculos.Testes.Integracao.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;

namespace LocadoraDeVeiculos.Testes.Integracao.ModuloTaxas;

[TestClass]
[TestCategory("Integração")]
public class RepositorioTaxaEmOrmTests : RepositorioEmOrmTestsBase
{
    [TestMethod]
    public void Deve_Inserir_Taxa()
    {
        var taxa = Builder<TaxaServico>
            .CreateNew()
            .With(t => t.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Build();

        repositorioTaxa.Cadastrar(taxa);

        var taxaSelecionada = repositorioTaxa.SelecionarPorId(taxa.Id);

        Assert.IsNotNull(taxaSelecionada);
        Assert.AreEqual(taxa, taxaSelecionada);
    }

    [TestMethod]
    public void Deve_Editar_Taxa()
    {
        var taxa = Builder<TaxaServico>
            .CreateNew()
            .With(t => t.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        taxa.Nome = "Taxa Atualizada";
        taxa.Valor = 100.0m;

        repositorioTaxa.Editar(taxa);

        var taxaSelecionada = repositorioTaxa.SelecionarPorId(taxa.Id);

        Assert.IsNotNull(taxaSelecionada);
        Assert.AreEqual(taxa, taxaSelecionada);
    }

    [TestMethod]
    public void Deve_Excluir_Taxa()
    {
        var taxa = Builder<TaxaServico>
            .CreateNew()
            .With(t => t.Id = 0)
            .With(g => g.EmpresaId = usuarioAutenticado.Id)
            .Persist();

        repositorioTaxa.Excluir(taxa);

        var taxaSelecionada = repositorioTaxa.SelecionarPorId(taxa.Id);

        var taxas = repositorioTaxa.SelecionarTodos();

        Assert.IsNull(taxaSelecionada);
        Assert.AreEqual(0, taxas.Count);
    }
}