using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opah.Lib.HttpBase.Interfaces;
using Opah.Lib.HttpBase.Messages;
using Opah.Lib.Logger;
using System;
using System.IO;
using System.Net;

namespace Opah.Lib.HttpBase.Util
{
    public class ResponseUtil : IResponseUtil
    {
        public IActionResult GetErrorResponse(HttpContext context, string message, System.Exception exception, IOpahLogger log)
        {
            string code = log.Log(LogType.Error, exception).ToString();
            return GetResponse(context, new ErroResponse(new MessageData(message, code)), HttpStatusCode.BadRequest);
        }

        public IActionResult GetErrorResponse(HttpContext context, System.Exception exception, IOpahLogger log)
        {
            return GetErrorResponse(context, exception.Message, exception, log);
        }

        public IActionResult GetErrorResponse(HttpContext context, System.Exception exception, IOpahLogger log, HttpStatusCode statusCode)
        {
            return GetErrorResponse(context, exception.Message, exception, log, statusCode);
        }

        private IActionResult GetErrorResponse(HttpContext context, string message, System.Exception exception, IOpahLogger log, HttpStatusCode statusCode)
        {
            string code = log.Log(LogType.Error, exception).ToString();
            return GetResponse(context, new SucessoResponse(new MessageData(message, code)), statusCode);
        }

        public IActionResult GetResponse(HttpContext context, BaseResponse response, HttpStatusCode statusCode)
        {
            var result = new ObjectResult(response)
            {
                StatusCode = (int)statusCode
            };

            return result;
        }

        public IActionResult GetResponse(HttpContext context, BaseResponse response)
        {
            if (response.Valid)
            {
                return GetResponse(context, response, HttpStatusCode.OK);
            }

            return GetResponse(context, response, HttpStatusCode.BadRequest);
        }

        public IActionResult GetValidacaoResponse(HttpContext context, System.Exception exception, IOpahLogger log, HttpStatusCode statusCode)
        {
            var listaErros = exception.Message.Split('|');
            var listaMessage = new List<MessageData>();

            foreach (var item in listaErros)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    listaMessage.Add(new MessageData(item, Guid.NewGuid().ToString()));
                }
            }

            var response = new ErroValidacaoResponse(listaMessage);
            return GetResponse(context, response, statusCode);
        }
    }
}