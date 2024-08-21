using Opah.Lib.MicrosservicoBase.Exception;

namespace Opah.Lib.HttpBase.Exception
{
    public class ErroValidacaoException : OpahException
    {
        #region Public Constructors

        public ErroValidacaoException(string message) : base(message)
        {
        }

        #endregion Public Constructors
    }
}