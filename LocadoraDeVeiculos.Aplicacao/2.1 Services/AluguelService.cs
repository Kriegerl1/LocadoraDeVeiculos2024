﻿using FluentResults;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloClientes;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloAlugueis;
using LocadoraDeVeiculos.Dominio.ModuloPessoas.ModuloCondutores;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.Aplicacao.Services;
public class AluguelService
{
    readonly IRepositorioPlano _repositorioPlano;
    readonly IRepositorioCliente _repositorioCliente;
    readonly IRepositorioAluguel _repositorioAluguel;
    readonly IRepositorioVeiculo _repositorioVeiculo;
    readonly IRepositorioCondutor _repositorioCondutor;
    readonly IRepositorioTaxaEServicos _repositorioTaxa;
    readonly IRepositorioGrupoVeiculos _repositorioGrupoVeiculos;

    public AluguelService(
        IRepositorioPlano repositorioPlano, IRepositorioVeiculo repositorioVeiculo,
        IRepositorioAluguel repositorioAluguel, IRepositorioCliente repositorioCliente,
        IRepositorioCondutor repositorioCondutor, IRepositorioTaxaEServicos repositorioTaxa,
        IRepositorioGrupoVeiculos repositorioGrupoVeiculos)
    {
        _repositorioTaxa = repositorioTaxa;
        _repositorioPlano = repositorioPlano;
        _repositorioVeiculo = repositorioVeiculo;
        _repositorioCliente = repositorioCliente;
        _repositorioAluguel = repositorioAluguel;
        _repositorioCondutor = repositorioCondutor;
        _repositorioGrupoVeiculos = repositorioGrupoVeiculos;
    }
    public Result<Aluguel> Cadastrar(Aluguel aluguel)
    {
        BuscarRegistros(aluguel);

        _repositorioAluguel.Cadastrar(aluguel);

        return Result.Ok(aluguel);
    }

    public Result<Aluguel> SelecionarId(int id)
    {
        var aluguel = _repositorioAluguel.SelecionarPorId(id);

        BuscarRegistros(aluguel);

        if (aluguel is null)
            return Result.Fail("Não foi encontrado o aluguel.");

        return Result.Ok(aluguel);
    }

    public Result<List<Aluguel>> SelecionarTodos()
    {
        var alugueis = _repositorioAluguel.SelecionarTodos();
        if (alugueis is null)
            return Result.Fail("Não foi possível encontrar nenhum registro.");

        return Result.Ok(alugueis);
    }

    private void BuscarRegistros(Aluguel aluguel)
    {
        var condutor = _repositorioCondutor.SelecionarPorId(aluguel.CondutorId);
        aluguel.Condutor = condutor;

        var plano = _repositorioPlano.SelecionarPorId(aluguel.PlanoId);
        var veiculo = _repositorioVeiculo.SelecionarPorId(aluguel.VeiculoId);
        var grupo = _repositorioGrupoVeiculos.SelecionarPorId(aluguel.GrupoId);
        var cliente = _repositorioCliente.SelecionarPorId(condutor.ClienteId);
        

        aluguel.Plano = plano;
        aluguel.Grupo = grupo;
        aluguel.Veiculo = veiculo;
        aluguel.Cliente = cliente;
    }
}