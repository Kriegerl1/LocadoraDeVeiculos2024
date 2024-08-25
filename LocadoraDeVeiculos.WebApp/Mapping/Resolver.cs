﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class Resolver : IValueResolver<Object?, Object, IEnumerable<SelectListItem>?>
{
    readonly IRepositorioGrupoVeiculos _repositorioGrupo;

    public Resolver(IRepositorioGrupoVeiculos repositorioGrupo)
    {
        _repositorioGrupo = repositorioGrupo;
    }

    public IEnumerable<SelectListItem>? Resolve(object? source, object destination, IEnumerable<SelectListItem>? destMember, ResolutionContext context)
    {
        return _repositorioGrupo.SelecionarTodos()
            .Select(grupo => new SelectListItem(
                grupo.Nome,
                grupo.Id.ToString()
                )
            );
    }
}