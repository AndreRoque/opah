namespace Opah.Consolidado.Application.Interfaces
{
    public interface IInfoService
    {
        #region Public Methods

        Guid GetInstanceHash();

        string GetMaxMemory();

        #endregion Public Methods
    }
}