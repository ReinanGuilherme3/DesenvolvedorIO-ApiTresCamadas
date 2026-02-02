using DevIO.Api.ViewModels;
using DevIO.Domain.Entities;

namespace DevIO.Api.AutoMapper;

public static class FornecedorEntidadeMap
{
    public static FornecedorViewModel MapearParaViewModel(this Fornecedor entidade)
        => new()
        {
            Id = entidade.Id,
            Nome = entidade.Nome,
            Documento = entidade.Documento,
            TipoFornecedor = entidade.TipoFornecedor,
            Ativo = entidade.Ativo,
            Endereco = entidade.Endereco?.MapearParaViewModel(),
            Produtos = entidade.Produtos?.Select(p => p.MapearParaViewModel()).ToList()
        };
}
