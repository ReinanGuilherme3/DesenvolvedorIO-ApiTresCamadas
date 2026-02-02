using DevIO.Api.ViewModels;
using DevIO.Domain.Entities;

namespace DevIO.Api.AutoMapper;

public static class ProdutoViewModelMap
{
    public static Produto MapearParaEntidade(this ProdutoViewModel viewModel)
        => new()
        {
            Ativo = viewModel.Ativo,
            DataCadastro = viewModel.DataCadastro,
            Descricao = viewModel.Descricao,
            FornecedorId = viewModel.FornecedorId,
            Id = viewModel.Id,
            Nome = viewModel.Nome,
            Valor = viewModel.Valor
        };
}
