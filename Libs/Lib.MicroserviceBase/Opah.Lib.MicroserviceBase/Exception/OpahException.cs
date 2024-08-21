using System;

namespace Opah.Lib.MicrosservicoBase.Exception
{
    public class OpahException : ApplicationException
    {
        #region Public Constructors

        public OpahException(string message) : base(message)
        {
        }

        #endregion Public Constructors
    }
}