using Opah.Lib.HttpBase.Interfaces;
using Opah.Lib.HttpBase.Messages;
using System.Runtime.Serialization;

namespace Opah.Consolidado.Application.Messages.Responses
{
    [DataContract]
    public class ConsolidadoResponse : SucessoResponse, IOpahResponse
    {
        #region Public Properties

        [DataMember(Name = "saldo")]
        public decimal Saldo { get; set; }

        [DataMember(Name = "lancamentos")]
        public List<Lancamento> Lancamentos { get; set; }

        #endregion Public Properties
    }
}