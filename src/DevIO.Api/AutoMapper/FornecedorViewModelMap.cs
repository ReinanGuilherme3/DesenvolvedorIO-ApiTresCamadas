using DevIO.Api.ViewModels;
using DevIO.Domain.Entities;

namespace DevIO.Api.AutoMapper;

public static class FornecedorViewModelMap
{
    public static Fornecedor MapearParaEntidade(this FornecedorViewModel viewModel)
        => new()
        {
            //Id = viewModel.Id,
            Nome = viewModel.Nome,
            Documento = viewModel.Documento,
            TipoFornecedor = viewModel.TipoFornecedor,
            Ativo = viewModel.Ativo,
            Endereco = viewModel.Endereco?.MapearParaEntidade(),
            Produtos = viewModel.Produtos?.Select(p => p.MapearParaEntidade()).ToList()
        };
}
