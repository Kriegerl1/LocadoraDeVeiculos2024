﻿using AutoMapper;
using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Services;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos;
using LocadoraDeVeiculos.WebApp.Controllers.Shared;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class TaxasController : WebController
{
    readonly IMapper _mapeador;
    readonly TaxasService _serviceTaxas;

    public TaxasController(
        IMapper mapeador,
        TaxasService serviceTaxas,
        AuthService authService) : base(authService)
    {
        _mapeador = mapeador;
        _serviceTaxas = serviceTaxas;
    }

    public IActionResult Listar()
    {
        var resultado = _serviceTaxas.SelecionarTodos(EmpresaId.GetValueOrDefault());

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var taxas = resultado.Value;

        var listarVm = _mapeador.Map<IEnumerable<ListarTaxasViewModel>>(taxas);

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View(listarVm);
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = _serviceTaxas.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var taxas = resultado.Value;

        var editarVm = _mapeador.Map<FormTaxasViewModel>(taxas);

        return View(editarVm);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(FormTaxasViewModel cadastroVm)
    {
        if (!ModelState.IsValid)
            return View(cadastroVm);

        var taxa = _mapeador.Map<TaxaServico>(cadastroVm);

        var resultado = _serviceTaxas.Cadastrar(taxa);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi cadastrado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = _serviceTaxas.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var taxa = resultado.Value;

        var editarVm = _mapeador.Map<FormTaxasViewModel>(taxa);

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(FormTaxasViewModel editarVm)
    {
        var taxa = _mapeador.Map<TaxaServico>(editarVm);

        var resultado = _serviceTaxas.Editar(taxa);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = _serviceTaxas.SelecionarId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var taxa = resultado.Value;

        var excluirVM = _mapeador.Map<FormTaxasViewModel>(taxa);

        return View(excluirVM);
    }

    [HttpPost]
    public IActionResult Excluir(FormTaxasViewModel excluirVm)
    {


        var resultado = _serviceTaxas.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro foi deletado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }
}
