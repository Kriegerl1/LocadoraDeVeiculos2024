﻿using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloTaxas;

namespace LocadoraDeVeiculos.WebApp.Models;

public class FormAluguelViewModel
{
    public int Id { get; set; }
    public int Entrada { get; set; } = 1000;
    public IEnumerable<SelectListItem>? Condutores { get; set; }
    public IEnumerable<SelectListItem>? Veiculos { get; set; }
    public IEnumerable<SelectListItem>? Clientes { get; set; }
    public IEnumerable<SelectListItem>? Planos { get; set; }
    public IEnumerable<SelectListItem>? Grupos { get; set; }
    public DateTime DataLocacao { get; set; } = DateTime.UtcNow;
    public DateTime? DateDevolucaoPrevista { get; set; } = DateTime.UtcNow;
    public int PlanoId { get; set; }
    public int VeiculoId { get; set; }
    public int GrupoId { get; set; }
    public int CondutorId { get; set; }
    public int SeguroId { get; set; }
    public int TaxaServicoId { get; set; }
}
public class ListarAluguelViewModel : FormAluguelViewModel
{
    public string Condutor { get; set; }
    public string Veiculo { get; set; }
    public string Cliente { get; set; }
    public string Plano { get; set; }
    public string Seguro { get; set; }
    public string Grupo { get; set; }
}
public class CadastroAluguelViewModel : FormAluguelViewModel
{
    public IEnumerable<SelectListItem>? Condutores { get; set; }
    public IEnumerable<SelectListItem>? Veiculos { get; set; }
    public IEnumerable<SelectListItem>? Clientes { get; set; }
    public IEnumerable<SelectListItem>? Planos { get; set; }
    public IEnumerable<SelectListItem>? Grupos { get; set; }
    public bool Checado {  get; set; }
    public List<TaxaServico>? Taxas { get; set; }
    public List<int> taxasSelecionadas { get; set; } = new();

}
public class ExcluirAluguelViewModel : FormAluguelViewModel { }
public class EditarAluguelViewModel : FormAluguelViewModel { }
public class DetalhesAluguelViewModel : FormAluguelViewModel { }
