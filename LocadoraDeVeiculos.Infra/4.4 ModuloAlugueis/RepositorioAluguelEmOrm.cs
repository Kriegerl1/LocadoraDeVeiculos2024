﻿using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.ModuloAlugueis.ModuloAlugueis;
using LocadoraDeVeiculos.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.ModuloAlugueis;
public class RepositorioAluguelEmOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
{
    public RepositorioAluguelEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    public List<Aluguel> Filtrar(Func<Aluguel, bool> predicate)
    {
        throw new NotImplementedException();
    }

    protected override DbSet<Aluguel> ObterRegistros()
    {
        return _dbContext.Alugueis;
    }

    public override Aluguel? SelecionarPorId(int id)
    {
        return _dbContext.Alugueis
            .Include(c => c.Condutor)
            .ThenInclude(c=>c.Cliente)
            .Include(c => c.Veiculo)
            .Include(v => v.Grupo)
            .Include(c => c.Plano)
            .Include(c=>c.Taxas)
            .FirstOrDefault(c => c.Id == id)!;
    }
    public override List<Aluguel> SelecionarTodos()
    {
        return _dbContext.Alugueis.Include(c => c.Condutor)
            .Include(c => c.Veiculo)
            .Include(v => v.Grupo)
            .Include(c => c.Plano)
            .Include(c=>c.Taxas)
            .ToList();
    }
}
