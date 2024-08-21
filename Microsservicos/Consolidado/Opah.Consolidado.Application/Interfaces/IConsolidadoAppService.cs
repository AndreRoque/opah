using Opah.Lib.HttpBase.Messages;

namespace Opah.Consolidado.Application.Interfaces
{
    public interface IConsolidadoAppService
    {
        #region Public Methods

        BaseResponse ObterConsolidado();

        #endregion Public Methods
    }
}