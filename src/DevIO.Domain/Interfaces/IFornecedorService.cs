using DevIO.Domain.Entities;

namespace DevIO.Domain.Interfaces;

public interface IFornecedorService : IDisposable
{
    Task Adicionar(Fornecedor entity);
    Task Atualizar(Fornecedor entity);
    Task Remover(Guid id);
}
