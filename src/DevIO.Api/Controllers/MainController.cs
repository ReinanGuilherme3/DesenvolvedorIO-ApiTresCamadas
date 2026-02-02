using DevIO.Domain.Interfaces;
using DevIO.Domain.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace DevIO.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class MainController(INotificador _notificador) : ControllerBase
{
    protected bool OperacaoValida()
    {
        return !_notificador.TemNotificacoes();
    }

    protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object? result = null)
    {
        if (OperacaoValida())
        {
            return new ObjectResult(result)
            {
                StatusCode = Convert.ToInt32(statusCode)
            };
        }

        return BadRequest(new
        {
            errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
        return CustomResponse();
    }

    protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);
        foreach (var error in errors)
        {
            var errorMsg = error.Exception is null ? error.ErrorMessage : error.Exception.Message;
            NotificarErro(errorMsg);
        }
    }

    protected void NotificarErro(string error)
        => _notificador.Handle(new Notificacao(error));
}
