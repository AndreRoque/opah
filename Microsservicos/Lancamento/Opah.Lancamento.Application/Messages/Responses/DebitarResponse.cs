using Opah.Lib.HttpBase.Interfaces;
using Opah.Lib.HttpBase.Messages;
using System.Runtime.Serialization;

namespace Opah.Lancamento.Application.Messages.Responses
{
    [DataContract]
    public class DebitarResponse : SucessoResponse, IOpahResponse
    {

    }    
}