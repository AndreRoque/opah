using Opah.Consolidado.API.Routes;
using Opah.Consolidado.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Opah.Consolidado.API.Controllers
{
    /// <summary>
    /// Healthcheck
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public class HealthCheckController : Controller
    {
        #region Private Fields

        private readonly IInfoService _infoService;

        #endregion Private Fields

        #region Public Constructors

        public HealthCheckController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Endpoint para HealthCheck
        /// </summary>
        /// <returns></returns>
        [Route(RouteConst.HealthCheck)]
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult HealthCheck()
        {
            string env = _infoService.GetMaxMemory();

            if (env == null)
            {
                return new ObjectResult($"healthy")
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }

            long memoryUsed = GC.GetTotalMemory(false);
            long maxMemory;

            maxMemory = Convert.ToInt64(env);

            if (memoryUsed <= maxMemory)
            {
                return new ObjectResult($"healthy: memory = {memoryUsed}")
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }

            return new ObjectResult($"unhealthy: memory = {memoryUsed}")
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        #endregion Public Methods
    }
}