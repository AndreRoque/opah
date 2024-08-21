using Opah.Lib.HttpBase.Messages;

namespace Opah.Lib.HttpBase.Interfaces
{
    public interface IOpahResponse
    {
        #region Public Methods

        void AddMessage(MessageData messageData);

        void SetStatus(bool status);

        void SetSuccess();

        #endregion Public Methods
    }
}