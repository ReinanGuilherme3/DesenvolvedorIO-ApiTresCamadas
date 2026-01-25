using DevIO.Domain.Entities;
using DevIO.Domain.Interfaces;

namespace DevIO.Domain.Services;

internal class ProdutoService : BaseService, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Adicionar(Produto entity)
    {
        await _produtoRepository.Adicionar(entity);
    }

    public async Task Atualizar(Produto entity)
    {
        await _produtoRepository.Atualizar(entity);
    }

    public async Task Remover(Guid id)
    {
        await _produtoRepository.Remover(id);
    }

    public void Dispose()
    {
        _produtoRepository.Dispose();
    }
}
