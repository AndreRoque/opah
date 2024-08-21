namespace Opah.Lib.HttpBase.Messages
{
    public class SucessoResponse : BaseResponse
    {
        #region Public Constructors

        public SucessoResponse(MessageData messageData) : base(messageData, true)
        {
            SetSuccess();
        }

        public SucessoResponse()
        {
            SetSuccess();
        }

        #endregion Public Constructors
    }
}