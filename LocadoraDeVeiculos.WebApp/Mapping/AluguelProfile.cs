﻿using AutoMapper;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class AluguelProfile : Profile
{
    public AluguelProfile()
    {
        CreateMap<Aluguel, ListarAluguelViewModel>()
            .ForMember(vm => vm.Condutor, opt => opt.MapFrom(v => v.Condutor.Nome.ToString()))
            .ForMember(vm => vm.Plano, opt => opt.MapFrom(v => v.Plano.TipoPlano.ToString()))
            .ForMember(vm => vm.Veiculo, opt => opt.MapFrom(v => v.Veiculo.Modelo.ToString()))
            .ForMember(vm => vm.Grupo, opt => opt.MapFrom(v => v.Grupo.Nome.ToString()));

        CreateMap<Aluguel, EditarAluguelViewModel>()
            .ForMember(vm => vm.Clientes, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Grupos, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Planos, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Veiculos, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Condutores, opt => opt.MapFrom<Resolver>());

        CreateMap<Aluguel, FinalizarAluguelViewModel>()
            .ForMember(vm => vm.Clientes, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Grupos, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Planos, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Veiculos, opt => opt.MapFrom<Resolver>())
            .ForMember(vm => vm.Condutores, opt => opt.MapFrom<Resolver>()); ;

        CreateMap<CadastroAluguelViewModel, Aluguel>();

        CreateMap<EditarAluguelViewModel, Aluguel>()
            .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
            .ForMember(dest => dest.GrupoId, opt => opt.MapFrom(src => src.GrupoId))
            .ForMember(dest => dest.PlanoId, opt => opt.MapFrom(src => src.PlanoId))
            .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
            .ForMember(dest => dest.CondutorId, opt => opt.MapFrom(src => src.CondutorId));

        CreateMap<Aluguel, PrefinalizarAluguelViewModel>();
        
        CreateMap<PrefinalizarAluguelViewModel, Aluguel>();

        CreateMap<Aluguel, ExcluirAluguelViewModel>();

        CreateMap<Aluguel, DetalhesAluguelViewModel>()
            .ForMember(vm => vm.Taxas, opt => opt.MapFrom(c => c.Taxas)); ;
    }
}
