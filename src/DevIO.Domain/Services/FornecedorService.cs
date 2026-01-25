using DevIO.Domain.Entities;
using DevIO.Domain.Interfaces;

namespace DevIO.Domain.Services;

public class FornecedorService : BaseService, IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task Adicionar(Fornecedor entity)
    {
        await _fornecedorRepository.Adicionar(entity);
    }

    public async Task Atualizar(Fornecedor entity)
    {
        await _fornecedorRepository.Atualizar(entity);
    }

    public async Task Remover(Guid id)
    {
        await _fornecedorRepository.Remover(id);
    }
    public void Dispose()
    {
        _fornecedorRepository?.Dispose();
    }
}
