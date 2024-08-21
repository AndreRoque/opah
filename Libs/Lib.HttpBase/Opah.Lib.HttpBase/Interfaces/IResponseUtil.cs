using Opah.Lib.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Opah.Lib.HttpBase.Messages;

namespace Opah.Lib.HttpBase.Interfaces
{
    public interface IResponseUtil
    {
        #region Public Methods

        IActionResult GetErrorResponse(HttpContext context, string message, System.Exception exception, IOpahLogger log);

        IActionResult GetErrorResponse(HttpContext context, System.Exception exception, IOpahLogger log);

        IActionResult GetErrorResponse(HttpContext context, System.Exception exception, IOpahLogger log, HttpStatusCode statusCode);

        IActionResult GetResponse(HttpContext context, BaseResponse response, HttpStatusCode statusCode);

        IActionResult GetResponse(HttpContext context, BaseResponse response);

        IActionResult GetValidacaoResponse(HttpContext context, System.Exception exception, IOpahLogger log, HttpStatusCode statusCode);

        #endregion Public Methods
    }
}