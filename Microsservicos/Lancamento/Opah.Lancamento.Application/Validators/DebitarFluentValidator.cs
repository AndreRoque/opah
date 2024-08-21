using FluentValidation;
using Opah.Lancamento.Application.Messages.Requests;

namespace Opah.Lancamento.Application.Validators.Fluent
{
    public class DebitarFluentValidator : AbstractValidator<DebitarRequest>
    {
        #region Public Constructors

        public DebitarFluentValidator()
        {
            RuleFor(v => v.Valor)
                .NotEmpty().WithMessage("Informe o valor para debito!")
                .LessThan(100000).WithMessage("O valor para debito não pode ser maior que 100000")
                .GreaterThan(0).WithMessage("O valor deve ser positivo");
        }

        #endregion Public Constructors
    }
}