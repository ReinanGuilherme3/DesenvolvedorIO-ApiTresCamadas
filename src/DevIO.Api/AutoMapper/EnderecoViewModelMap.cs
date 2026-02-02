using DevIO.Api.ViewModels;
using DevIO.Domain.Entities;

namespace DevIO.Api.AutoMapper;

public static class EnderecoViewModelMap
{
    public static Endereco MapearParaEntidade(this EnderecoViewModel viewModel)
        => new()
        {
            Id = viewModel.Id,
            FornecedorId = viewModel.FornecedorId,
            Logradouro = viewModel.Logradouro,
            Numero = viewModel.Numero,
            Complemento = viewModel.Complemento,
            Cep = viewModel.Cep,
            Bairro = viewModel.Bairro,
            Cidade = viewModel.Cidade,
            Estado = viewModel.Estado
        };
}