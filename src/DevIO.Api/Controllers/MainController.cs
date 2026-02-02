using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class MainController : ControllerBase
{
    protected bool OperacaoValida()
    {
        return true;
    }

    protected ActionResult CustomResponse(object? result = null)
    {
        if (OperacaoValida())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }
        return BadRequest(new
        {
            success = false,
            errors = new[] { "Ocorreu um erro na operação." }
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);
        foreach (var error in errors)
        {
            // Adicionar notificação de erro (simulado aqui)
        }
        return CustomResponse();
    }

    protected void AdicionarErro(string error)
    {
        // Adicionar notificação de erro (simulado aqui)
    }
}
