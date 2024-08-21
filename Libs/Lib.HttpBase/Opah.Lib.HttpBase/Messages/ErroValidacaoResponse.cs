namespace Opah.Lib.HttpBase.Messages
{
    public class ErroValidacaoResponse : BaseResponse
    {
        #region Public Constructors

        public ErroValidacaoResponse(IList<MessageData> listaMessageData)
        {
            foreach (var messageData in listaMessageData)
            {
                AddMessage(messageData);
            }

            SetStatus(false);
        }

        #endregion Public Constructors
    }    
}