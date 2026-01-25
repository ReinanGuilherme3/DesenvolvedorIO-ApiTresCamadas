using DevIO.Domain.Entities;

namespace DevIO.Domain.Interfaces;

public interface IFornecedorService : IDisposable
{
    Task Adicionar(Fornecedor entidade);
    Task Atualizar(Fornecedor entidade);
    Task Remover(Guid id);
}
