using DevIO.Data.Context;
using DevIO.Domain.Entities;
using DevIO.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories;

public class FornecedorRepository(DevIODbContext context) : Repository<Fornecedor>(context), IFornecedorRepository
{
    public async Task<Endereco?> ObterEnderecoPorFornecedor(Guid fornecedorId)
        => await Db.Enderecos
            .AsNoTracking()
            .FirstOrDefaultAsync();

    public async Task<Fornecedor?> ObterFornecedorEndereco(Guid id)
        => await DbSet
                .AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync();

    public async Task<Fornecedor?> ObterFornecedorProdutosEndereco(Guid id)
        => await DbSet
                .AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);

    public async Task RemoverEnderecoFornecedor(Endereco endereco)
    {
        Db.Enderecos.Remove(endereco);
        await SaveChanges();
    }
}
