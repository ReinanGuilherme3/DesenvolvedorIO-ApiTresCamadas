using DevIO.Domain.Entities;
using DevIO.Domain.Entities.Validations;
using DevIO.Domain.Interfaces;

namespace DevIO.Domain.Services;

public class ProdutoService : BaseService, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Adicionar(Produto entidade)
    {
        if (!ExecutarValidacao(new ProdutoValidation(), entidade)) return;

        await _produtoRepository.Adicionar(entidade);
    }

    public async Task Atualizar(Produto entidade)
    {
        if (!ExecutarValidacao(new ProdutoValidation(), entidade)) return;

        await _produtoRepository.Atualizar(entidade);
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
