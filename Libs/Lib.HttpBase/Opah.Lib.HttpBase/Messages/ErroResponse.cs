namespace Opah.Lib.HttpBase.Messages
{
    public class ErroResponse : BaseResponse
    {
        #region Public Constructors

        public ErroResponse(MessageData messageData) : base(messageData, false)
        {
            SetStatus(false);
        }

        public ErroResponse()
        {
            SetStatus(false);
        }

        #endregion Public Constructors
    }    
}