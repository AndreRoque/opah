namespace Opah.Lancamento.Application.Interfaces
{
    public interface IInfoService
    {
        #region Public Methods

        Guid GetInstanceHash();

        string GetMaxMemory();

        #endregion Public Methods
    }
}