using DevIO.Domain.Entities;
using DevIO.Domain.Entities.Validations;
using DevIO.Domain.Interfaces;

namespace DevIO.Domain.Services;

public class FornecedorService : BaseService, IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task Adicionar(Fornecedor entidade)
    {
        var fornecedorValidation = ExecutarValidacao(new FornecedorValidation(), entidade);
        var enderecoValidation = ExecutarValidacao(new EnderecoValidation(), entidade.Endereco);

        if (!fornecedorValidation || !enderecoValidation) return;

        await _fornecedorRepository.Adicionar(entidade);
    }

    public async Task Atualizar(Fornecedor entidade)
    {
        if (!ExecutarValidacao(new FornecedorValidation(), entidade)) return;

        await _fornecedorRepository.Atualizar(entidade);
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
