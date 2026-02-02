using DevIO.Api.ViewModels;
using DevIO.Domain.Entities;

namespace DevIO.Api.AutoMapper;

public static class ProdutoViewModelMap
{
    public static Produto MapearParaEntidade(this ProdutoViewModel viewModel)
        => new()
        {
            //Id = viewModel.Id,
            Ativo = viewModel.Ativo,
            DataCadastro = viewModel.DataCadastro,
            Descricao = viewModel.Descricao,
            FornecedorId = viewModel.FornecedorId,
            Nome = viewModel.Nome,
            Valor = viewModel.Valor
        };
}
