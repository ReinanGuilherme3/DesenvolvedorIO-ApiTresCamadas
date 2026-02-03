using DevIO.Data.Context;
using DevIO.Domain.Entities;
using DevIO.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories;

public class ProdutoRepository(DevIODbContext context) : Repository<Produto>(context), IProdutoRepository
{
    public async Task<Produto?> ObterProdutoFornecedor(Guid id)
        => await DbSet
            .AsNoTracking()
            .Include(p => p.Fornecedor)
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Produto>?> ObterProdutosFornecedores()
        => await DbSet
            .AsNoTracking()
            .Include(p => p.Fornecedor)
            .OrderBy(p => p.Nome)
            .ToListAsync();

    public async Task<IEnumerable<Produto>?> ObterProdutosPorFornecedor(Guid fornecedorId)
        => await Buscar(p => p.FornecedorId == fornecedorId);
}
