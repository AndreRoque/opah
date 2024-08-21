using Opah.Lancamento.Application.Interfaces;
using Opah.Lib.HttpBase.Messages;
using Opah.Lancamento.Application.Messages.Requests;
using Opah.Lib.HttpBase.Exception;
using Opah.Lancamento.Application.Validators.Fluent;

namespace Opah.Lancamento.Application.Validators
{
    public class LancamentoValidator : ILancamentoAppService
    {
        #region Private Fields

        private ILancamentoAppService _service;

        #endregion Private Fields

        #region Public Constructors

        public LancamentoValidator(ILancamentoAppService service)
        {
            _service = service;
        }

        #endregion Public Constructors

        #region Public Methods

        public BaseResponse Creditar(CreditarRequest request)
        {
            var result = new CreditarFluentValidator().Validate(request);

            if (!result.IsValid)
            {
                string messages = "|";

                foreach (var error in result.Errors)
                {
                    messages += error.ErrorMessage + "|";
                }

                throw new ErroValidacaoException(messages);
            }

            return _service.Creditar(request);
        }

        public BaseResponse Debitar(DebitarRequest request)
        {
            var result = new DebitarFluentValidator().Validate(request);

            if (!result.IsValid)
            {
                string messages = "|";

                foreach (var error in result.Errors)
                {
                    messages += error.ErrorMessage + "|";
                }

                throw new ErroValidacaoException(messages);
            }

            return _service.Debitar(request);
        }

        #endregion Public Methods
    }
}