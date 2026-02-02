using DevIO.Api.AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevIO.Api.Controllers;

public class FornecedoresController(
    IFornecedorRepository _fornecedorRepository,
    IFornecedorService _fornecedorService,
    INotificador _notificador) : MainController(_notificador)
{

    [HttpGet]
    public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
    {
        var result = await _fornecedorRepository.ObterTodos();
        var response = result.Select(f => f.MapearParaViewModel());
        return response;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
    {
        var result = await _fornecedorRepository.ObterPorId(id);
        if (result is null) return NotFound();

        var response = result.MapearParaViewModel();
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var fornecedor = fornecedorViewModel.MapearParaEntidade();
        await _fornecedorService.Adicionar(fornecedor);
        return CustomResponse(HttpStatusCode.Created, fornecedorViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
    {
        if (id != fornecedorViewModel.Id)
        {
            NotificarErro("O id informado não é o mesmo que foi passado na query");
            return CustomResponse();
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var fornecedor = await _fornecedorRepository.ObterPorId(id);
        if (fornecedor is null) return NotFound();

        fornecedor = fornecedorViewModel.MapearParaEntidade();
        await _fornecedorService.Atualizar(fornecedor);
        return CustomResponse(HttpStatusCode.NoContent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
    {
        await _fornecedorService.Remover(id);
        return CustomResponse(HttpStatusCode.NoContent);
    }
}

