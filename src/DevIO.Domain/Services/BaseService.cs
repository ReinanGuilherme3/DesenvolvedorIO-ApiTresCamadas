using DevIO.Domain.Entities;
using DevIO.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Domain.Services;

public abstract class BaseService
{
    private readonly INotificador _notificador;

    protected BaseService(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected void Notificar(ValidationResult validacao)
    {
        foreach (var error in validacao.Errors)
            Notificar(error.ErrorMessage);
    }

    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new(mensagem));
    }

    protected bool ExecutarValidacao<TValidation, TEntity>(TValidation validacao, TEntity entidade)
        where TValidation : AbstractValidator<TEntity>
        where TEntity : Entity
    {
        var validator = validacao.Validate(entidade);
        if (validator.IsValid) return true;

        Notificar(validator);

        return false;
    }
}
