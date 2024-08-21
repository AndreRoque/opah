using Opah.Lancamento.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Opah.Lancamento.Application.Services
{
    public class InfoService : IInfoService
    {
        #region Private Fields

        private Guid _instanceHash;
        private string _maxMemory;

        #endregion Private Fields

        #region Public Constructors

        public InfoService(IConfiguration config)
        {
            _instanceHash = Guid.NewGuid();
            _maxMemory = config["Opah.Lancamento-MaxMemory"];
        }

        #endregion Public Constructors

        #region Public Methods

        public Guid GetInstanceHash()
        {
            return _instanceHash;
        }

        public string GetMaxMemory()
        {
            return _maxMemory;
        }

        #endregion Public Methods
    }
}