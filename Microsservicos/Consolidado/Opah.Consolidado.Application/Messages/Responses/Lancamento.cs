using System.Runtime.Serialization;

namespace Opah.Consolidado.Application.Messages.Responses
{
    [DataContract]
    public class Lancamento
    {
        #region Public Properties

        [DataMember(Name = "data")]
        public DateTime Data { get; set; }

        [DataMember(Name = "valor")]
        public decimal Valor { get; set; }

        #endregion Public Properties
    }
}