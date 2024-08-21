using Opah.Consolidado.API.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Opah.Consolidado.Application.Messages.Responses;
using Opah.Lib.HttpBase.Messages;
using Opah.Consolidado.Application.Interfaces;

namespace Opah.Consolidado.API.Controllers
{
    /// <summary>
    /// Endpoints de lancamento
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public class ConsolidadoController : ControllerBase
    {
        #region Private Fields

        private readonly IConsolidadoAppService _service;

        #endregion Private Fields

        #region Public Constructors

        public ConsolidadoController(IConsolidadoAppService service)
        {
            _service = service;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Obter saldo consolidado
        /// </summary>
        [HttpGet]
        [Route(RouteConst.ObterConsolidado)]
        [ProducesResponseType(200, Type = typeof(ConsolidadoResponse))]
        [ProducesResponseType(400, Type = typeof(ErroResponse))]
        public IActionResult ObterConsolidado()
        {
            BaseResponse response = _service.ObterConsolidado();

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        #endregion Public Methods
    }
}