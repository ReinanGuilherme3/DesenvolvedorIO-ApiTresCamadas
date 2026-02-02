using DevIO.Api.ViewModels;
using DevIO.Domain.Entities;

namespace DevIO.Api.AutoMapper;

public static class ProdutoEntidadeMap
{
    public static ProdutoViewModel MapearParaViewModel(this Produto entidade)
        => new()
        {
            Id = entidade.Id,
            FornecedorId = entidade.FornecedorId,
            Nome = entidade.Nome,
            Descricao = entidade.Descricao,
            Valor = entidade.Valor,
            DataCadastro = entidade.DataCadastro,
            Ativo = entidade.Ativo,
            NomeFornecedor = entidade.Fornecedor?.Nome
        };
}
