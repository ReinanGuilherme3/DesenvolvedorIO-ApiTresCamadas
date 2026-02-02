using DevIO.Api.ViewModels;
using DevIO.Domain.Entities;

namespace DevIO.Api.AutoMapper;

public static class EnderecoEntidadeMap
{
    public static EnderecoViewModel MapearParaViewModel(this Endereco entidade)
        => new()
        {
            Id = entidade.Id,
            Logradouro = entidade.Logradouro,
            Numero = entidade.Numero,
            Complemento = entidade.Complemento,
            Bairro = entidade.Bairro,
            Cep = entidade.Cep,
            Cidade = entidade.Cidade,
            Estado = entidade.Estado,
            FornecedorId = entidade.FornecedorId
        };
}
