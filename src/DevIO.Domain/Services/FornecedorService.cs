using DevIO.Domain.Entities;
using DevIO.Domain.Entities.Validations;
using DevIO.Domain.Interfaces;

namespace DevIO.Domain.Services;

public class FornecedorService : BaseService, IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository fornecedorRepository, INotificador notificador) : base(notificador)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task Adicionar(Fornecedor entidade)
    {
        var fornecedorValidation = ExecutarValidacao(new FornecedorValidation(), entidade);
        var enderecoValidation = ExecutarValidacao(new EnderecoValidation(), entidade.Endereco);

        if (!fornecedorValidation || !enderecoValidation) return;

        var existeFornecedor = await _fornecedorRepository.Buscar(f => f.Documento == entidade.Documento);

        if (existeFornecedor.Any())
        {
            Notificar("Já existe um fornecedor com este documento informado.");
            return;
        }

        await _fornecedorRepository.Adicionar(entidade);
    }

    public async Task Atualizar(Fornecedor entidade)
    {
        if (!ExecutarValidacao(new FornecedorValidation(), entidade)) return;

        var existeFornecedor = await _fornecedorRepository.Buscar(f => f.Documento == entidade.Documento && f.Id != entidade.Id);
        if (existeFornecedor.Any())
        {
            Notificar("Já existe um fornecedor com este documento informado.");
            return;
        }

        await _fornecedorRepository.Atualizar(entidade);
    }

    public async Task Remover(Guid id)
    {
        var existeFornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);
        if (existeFornecedor is null)
        {
            Notificar("Fornecedor não existe!");
            return;
        }

        if (existeFornecedor.Produtos.Any())
        {
            Notificar("O fornecedor possui produtos cadastrados!");
            return;
        }

        var endereco = await _fornecedorRepository.ObterEnderecoPorFornecedor(id);
        if (endereco is not null)
        {
            await _fornecedorRepository.RemoverEnderecoFornecedor(endereco);
        }

        await _fornecedorRepository.Remover(id);
    }
    public void Dispose()
    {
        _fornecedorRepository?.Dispose();
    }
}
