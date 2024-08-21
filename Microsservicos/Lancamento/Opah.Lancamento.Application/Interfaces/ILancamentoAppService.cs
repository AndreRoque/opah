using Opah.Lancamento.Application.Messages.Requests;
using Opah.Lib.HttpBase.Messages;

namespace Opah.Lancamento.Application.Interfaces
{
    public interface ILancamentoAppService
    {
        #region Public Methods

        BaseResponse Debitar(DebitarRequest request);
        BaseResponse Creditar(CreditarRequest request);

        #endregion Public Methods
    }
}