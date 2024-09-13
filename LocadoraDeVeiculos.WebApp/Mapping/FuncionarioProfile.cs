﻿using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloPessoas;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class FuncionarioProfile :Profile
{
    public FuncionarioProfile()
    {
        CreateMap<CadastroFuncionarioViewModel, Funcionario>()
            .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

        CreateMap<Funcionario, ListarFuncionarioViewModel>();
    }
}
