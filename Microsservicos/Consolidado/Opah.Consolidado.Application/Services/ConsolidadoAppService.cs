using Opah.Consolidado.Application.Interfaces;
using Opah.Consolidado.Application.Messages.Responses;
using Opah.Consolidado.Infra.MongoDB.Repositories;
using Opah.Lib.HttpBase.Messages;
using Opah.Lib.Logger;

namespace Opah.Consolidado.Application.Services
{
    public class ConsolidadoAppService : IConsolidadoAppService
    {
        #region Private Fields

        private readonly IConsolidadoRepository _repository;
        private readonly IOpahLogger _log;

        #endregion Private Fields

        #region Public Constructors

        public ConsolidadoAppService(IConsolidadoRepository repository, IOpahLogger log)
        {
            _repository = repository;
            _log = log;
        }

        public BaseResponse ObterConsolidado()
        {
            var response = new ConsolidadoResponse();
            response.Lancamentos =  new List<Lancamento>();

            response.Saldo = _repository.BuscarSaldo();
            var listaLancamentos = _repository.ListarLancamentos();

            foreach (var item in listaLancamentos)
            {
                response.Lancamentos.Add(new Lancamento 
                { 
                    Data = item.Data, 
                    Valor = item.Valor,
                });
            }
            
            _log.Log(LogType.Information, $"Foi gerado um relatorio na data de {DateTime.Now}");

            response.SetSuccess();
            return response;
        }

        #endregion Public Constructors
    }
}