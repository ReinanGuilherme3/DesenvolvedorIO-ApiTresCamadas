using DevIO.Domain.Entities;

namespace DevIO.Domain.Interfaces;

public interface IProdutoService : IDisposable
{
    Task Adicionar(Produto entity);
    Task Atualizar(Produto entity);
    Task Remover(Guid id);
}
