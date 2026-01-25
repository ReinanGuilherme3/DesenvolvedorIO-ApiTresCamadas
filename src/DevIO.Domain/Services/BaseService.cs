using DevIO.Domain.Entities;
using FluentValidation;

namespace DevIO.Domain.Services;

public abstract class BaseService
{
    protected void Notificar(string mensagem)
    {
        // Implementar a lógica de notificação, por exemplo, armazenar mensagens de erro
    }
    protected bool ExecutarValidacao<TValidation, TEntity>(TValidation validacao, TEntity entidade)
        where TValidation : AbstractValidator<TEntity>
        where TEntity : Entity
    {
        var validator = validacao.Validate(entidade);
        if (validator.IsValid) return true;

        return false;
    }
}
