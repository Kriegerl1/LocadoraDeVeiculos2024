﻿using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculos.ModuloGrupoVeiculos;
public class GrupoVeiculos : EntidadeBase
{
    public string Nome { get; set; }
    public List<Veiculo>? Veiculos { get; set; }
    public GrupoVeiculos(){}
    public GrupoVeiculos(string nome)
    {
        Nome = nome;
        Veiculos = new List<Veiculo>();
    }

    public override string ToString()
    {
        return Nome;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (string.IsNullOrEmpty(Nome.Trim()))
            erros.Add("O grupo deve conter um nome.");

        if (Nome.Trim().Length < 3)
            erros.Add("O grupo deve conter ao menos tres caracteres.");

        return erros;
    }
}
