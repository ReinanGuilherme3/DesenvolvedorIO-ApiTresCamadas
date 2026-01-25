using DevIO.Domain.Entities;

namespace DevIO.Domain.Interfaces;

public interface IProdutoService : IDisposable
{
    Task Adicionar(Produto entidade);
    Task Atualizar(Produto entidade);
    Task Remover(Guid id);
}
