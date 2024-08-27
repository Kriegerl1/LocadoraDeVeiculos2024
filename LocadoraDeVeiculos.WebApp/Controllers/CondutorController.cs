﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.Aplicacao.Services;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class CondutorController : WebController
{
    readonly IMapper _mapeador;
    readonly ClienteService _serviceCliente;
    readonly CondutorService _serviceCondutor;

    public CondutorController(IMapper mapeador, ClienteService serviceCliente, CondutorService condutorService)
    {
        _mapeador = mapeador;
        _serviceCliente = serviceCliente;
        _serviceCondutor = condutorService;
    }

    public IActionResult Listar()
    {
        var resultado = _serviceCondutor.SelecionarTodos();

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var condutores = resultado.Value;

        var listarVM = _mapeador.Map<IEnumerable<ListarCondutorViewModel>>(condutores);

        return View(listarVM);
    }

    public IActionResult Detalhes(int id)
    {
        return View();
    }

    public IActionResult Cadastrar()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastroCondutorViewModel cadastroVm)
    
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(cadastroVm));

        var condutor = _mapeador.Map<Condutor>(cadastroVm);

        var resultado = _serviceCondutor.Cadastrar(condutor);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult()); ////Ainda não implementado

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{condutor.Id}] foi cadastrado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Editar(EditarCondutorViewModel editarVm)
    {
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Excluir()
    {
        return RedirectToAction(nameof(Listar));
    }

    private FormCondutorViewModel? CarregarDadosFormulario(
      CadastroCondutorViewModel? dadosPrevios = null)
    {
        var resultadoClientes = _serviceCliente.SelecionarTodos();

        if (resultadoClientes.IsFailed)
        {
            ApresentarMensagemFalha(resultadoClientes.ToResult());
            return null;
        }

        var Disponiveis = resultadoClientes.Value;

        if (dadosPrevios is null)
        {
            var formularioVm = new CadastroCondutorViewModel
            {
                Clientes = Disponiveis.Select(c => new SelectListItem(c.Nome, c.Id.ToString()))
            };
            return formularioVm;
        }

        dadosPrevios.Clientes = Disponiveis.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));
        return dadosPrevios;
    }
}
