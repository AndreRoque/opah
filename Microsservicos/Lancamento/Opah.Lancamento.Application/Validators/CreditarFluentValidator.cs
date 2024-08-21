using FluentValidation;
using Opah.Lancamento.Application.Messages.Requests;

namespace Opah.Lancamento.Application.Validators.Fluent
{
    public class CreditarFluentValidator : AbstractValidator<CreditarRequest>
    {
        #region Public Constructors

        public CreditarFluentValidator()
        {
            RuleFor(v => v.Valor)
                .NotEmpty().WithMessage("Informe o valor para credito!")
                .LessThan(100000).WithMessage("O valor para credito não pode ser maior que 100000")
                .GreaterThan(0).WithMessage("O valor deve ser positivo");
        }

        #endregion Public Constructors
    }
}