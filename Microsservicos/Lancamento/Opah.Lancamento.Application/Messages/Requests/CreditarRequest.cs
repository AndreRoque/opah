using Opah.Lib.HttpBase.Interfaces;
using System.Runtime.Serialization;

namespace Opah.Lancamento.Application.Messages.Requests
{
    [DataContract]
    public class CreditarRequest : IOpahRequest
    {
        #region Public Properties

        [DataMember(Name = "valor")]
        public decimal Valor { get; set; }

        #endregion Public Properties
    }
}