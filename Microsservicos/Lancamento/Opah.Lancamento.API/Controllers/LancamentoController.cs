using Opah.Lancamento.API.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Opah.Lancamento.Application.Messages.Responses;
using Opah.Lib.HttpBase.Messages;
using Opah.Lancamento.Application.Messages.Requests;
using Opah.Lancamento.Application.Interfaces;

namespace Opah.Lancamento.API.Controllers
{
    /// <summary>
    /// Endpoints de lancamento
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        #region Private Fields

        private readonly ILancamentoAppService _service;

        #endregion Private Fields

        #region Public Constructors

        public LancamentoController(ILancamentoAppService service)
        {
            _service = service;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Debitar
        /// </summary>
        [HttpPost]
        [Route(RouteConst.Debitar)]
        [ProducesResponseType(200, Type = typeof(DebitarResponse))]
        [ProducesResponseType(400, Type = typeof(ErroResponse))]
        public IActionResult Debitar([FromBody] DebitarRequest request)
        {
            BaseResponse response = _service.Debitar(request);

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Creditar
        /// </summary>
        [HttpPost]
        [Route(RouteConst.Creditar)]
        [ProducesResponseType(200, Type = typeof(CreditarResponse))]
        [ProducesResponseType(400, Type = typeof(ErroResponse))]
        public IActionResult Creditar([FromBody] CreditarRequest request)
        {
            BaseResponse response = _service.Creditar(request);

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        #endregion Public Methods
    }
}