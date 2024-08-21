using System.Runtime.Serialization;

namespace Opah.Lib.HttpBase.Messages
{
    [DataContract]
    public abstract class BaseResponse
    {
        #region Protected Constructors

        protected BaseResponse()
        {
            Valid = true;
            ListMessage = new List<MessageData>();
        }

        protected BaseResponse(MessageData messageData)
        {
            Valid = true;

            ListMessage = new List<MessageData>
            {
                messageData
            };
        }

        protected BaseResponse(MessageData messageData, bool valid)
        {
            Valid = valid;

            ListMessage = new List<MessageData>
            {
                messageData
            };
        }

        #endregion Protected Constructors

        #region Public Properties

        [DataMember(Name = "messages")]
        public List<MessageData> ListMessage { get; set; }

        [DataMember(Name = "valid")]
        public bool Valid { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void AddMessage(MessageData messageData)
        {
            ListMessage.Add(messageData);
        }

        public void SetStatus(bool status)
        {
            Valid = status;
        }

        public void SetSuccess()
        {
            SetStatus(true);
            ListMessage = new List<MessageData>();
            AddMessage(new MessageData("Operação executada com sucesso!", Guid.NewGuid().ToString()));
        }

        #endregion Public Methods
    }
}