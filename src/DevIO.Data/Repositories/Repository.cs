using DevIO.Data.Context;
using DevIO.Domain.Entities;
using DevIO.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevIO.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly DevIODbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(DevIODbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public virtual async Task Adicionar(TEntity entidade)
    {
        await DbSet.AddAsync(entidade);
        await SaveChanges();
    }

    public virtual async Task Atualizar(TEntity entidade)
    {
        DbSet.Update(entidade);
        await SaveChanges();
    }

    public virtual async Task<TEntity?> ObterPorId(Guid id)
        => await DbSet.FindAsync(id);

    public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        => await DbSet.ToListAsync();

    public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        => await DbSet.AsNoTracking().Where(predicate).ToListAsync();

    public virtual async Task Remover(Guid id)
    {
        var entidade = new TEntity { Id = id };
        DbSet.Remove(entidade);
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
        => await Db.SaveChangesAsync();

    public void Dispose()
    {
        Db?.Dispose();
    }
}
