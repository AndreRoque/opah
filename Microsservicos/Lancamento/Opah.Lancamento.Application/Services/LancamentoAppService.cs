using Opah.Lancamento.Application.Interfaces;
using Opah.Lancamento.Application.Messages.Requests;
using Opah.Lancamento.Application.Messages.Responses;
using Opah.Lancamento.Domain.Entities;
using Opah.Lancamento.Domain.Interfaces.Services;
using Opah.Lib.HttpBase.Messages;
using Opah.Lib.Logger;

namespace Opah.Lancamento.Application.Services
{
    public class LancamentoAppService : ILancamentoAppService
    {
        #region Private Fields

        private readonly ILancamentoService _service;
        private readonly IOpahLogger _log;

        #endregion Private Fields

        #region Public Constructors

        public LancamentoAppService(ILancamentoService service, IOpahLogger log)
        {
            _service = service;
            _log = log;
        }

        public BaseResponse Debitar(DebitarRequest request)
        {
            var response = new DebitarResponse();

            decimal saldo = _service.BuscarSaldo();

            var fluxoCaixa = new FluxoCaixa(saldo);

            _service.Debitar(request.Valor, fluxoCaixa);
            _log.Log(LogType.Information, $"Foi debitado um valor de {request.Valor} reais na data de {DateTime.Now}");

            response.SetSuccess();
            return response;
        }

        public BaseResponse Creditar(CreditarRequest request)
        {
            var response = new CreditarResponse();

            decimal saldo = _service.BuscarSaldo();

            var fluxoCaixa = new FluxoCaixa(saldo);

            _service.Creditar(request.Valor, fluxoCaixa);
            _log.Log(LogType.Information, $"Foi creditado um valor de {request.Valor} reais na data de {DateTime.Now}");

            response.SetSuccess();
            return response;
        }

        #endregion Public Constructors
    }
}