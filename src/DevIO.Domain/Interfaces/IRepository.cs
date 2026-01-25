using DevIO.Domain.Entities;
using System.Linq.Expressions;

namespace DevIO.Domain.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Adicionar(TEntity entity);
    Task Atualizar(TEntity entity);
    Task Remover(Guid id);
    Task<TEntity> ObterPorId(Guid id);
    Task<IEnumerable<TEntity>> ObterTodos();
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}
