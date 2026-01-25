using FluentValidation;

namespace DevIO.Domain.Entities.Validations;

public class ProdutoValidation : AbstractValidator<Produto>
{
    ProdutoValidation()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} de caracteres");

        RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} de caracteres");

        RuleFor(x => x.Valor)
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

    }
}
