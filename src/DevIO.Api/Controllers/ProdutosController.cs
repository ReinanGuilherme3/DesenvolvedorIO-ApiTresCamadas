using DevIO.Api.AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers;

public class ProdutosController(
    IProdutoRepository _produtoRepository,
    IProdutoService _produtoService) : MainController
{

    [HttpGet]
    public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
    {
        var result = await _produtoRepository.ObterTodos();
        var response = result.Select(p => p.MapearParaViewModel());
        return response;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
    {
        var result = await _produtoRepository.ObterPorId(id);
        if (result is null) return NotFound();

        var response = result.MapearParaViewModel();
        return response;
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var produto = produtoViewModel.MapearParaEntidade();
        await _produtoService.Adicionar(produto);

        return CustomResponse(produtoViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
    {
        if (id != produtoViewModel.Id)
        {
            AdicionarErro("O id informado não é o mesmo que foi passado na query");
            return CustomResponse();
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var produto = await _produtoRepository.ObterPorId(id);
        if (produto is null) return NotFound();

        produto = produtoViewModel.MapearParaEntidade();

        await _produtoService.Atualizar(produto);

        return CustomResponse(produtoViewModel);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
    {
        var produto = await _produtoRepository.ObterPorId(id);
        if (produto is null) return NotFound();
        await _produtoService.Remover(id);
        return CustomResponse();
    }
}
