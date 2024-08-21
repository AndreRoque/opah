using Opah.Consolidado.API.Routes;
using Opah.Consolidado.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Opah.Consolidado.API.Controllers
{
    /// <summary>
    /// Home
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        #region Private Fields

        private IConfiguration _config;
        private IInfoService _infoService;

        #endregion Private Fields

        #region Public Constructors

        public HomeController(IInfoService infoService, IConfiguration config)
        {
            _infoService = infoService;
            _config = config;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Verifica se a API esta em execução. Exibe o código da versão
        /// </summary>
        /// <returns></returns>
        [Route(RouteConst.Home)]
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Index()
        {
            string serviceName = _config["SERVICE_NAME"];
            string serviceVersion = _config["SERVICE_VERSION"];
            string environment = _config["ASPNETCORE_ENVIRONMENT"];

            var result = new ObjectResult($"{serviceName} em execução! - " +
                $"Versão: {serviceVersion} - " +
                $"Ambiente: {environment} - " +
                $"Hash da instancia: {_infoService.GetInstanceHash()}")
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            return result;
        }

        #endregion Public Methods
    }
}