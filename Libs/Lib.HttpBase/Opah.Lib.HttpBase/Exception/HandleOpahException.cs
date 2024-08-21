using Microsoft.AspNetCore.Mvc.Filters;
using Opah.Lib.HttpBase.Interfaces;
using Opah.Lib.HttpBase.Util;
using Opah.Lib.Logger;
using Opah.Lib.MicrosservicoBase.Exception;
using System;
using System.Net;
using System.Threading;

namespace Opah.Lib.HttpBase.Exception
{
    public class HandleOpahException : IExceptionFilter
    {
        public IOpahLogger _log { get; set; }

        public HandleOpahException(IOpahLogger log)
        {
            _log = log;
        }

        public void OnException(ExceptionContext filterContext)
        {
            IResponseUtil util = new ResponseUtil();

            filterContext.ExceptionHandled = true;

            switch (filterContext.Exception)
            {                
                case ErroValidacaoException:
                    filterContext.Result = util.GetValidacaoResponse(filterContext.HttpContext, filterContext.Exception, _log, HttpStatusCode.BadRequest);
                return;
                case Opah404Exception:
                    filterContext.Result = util.GetErrorResponse(filterContext.HttpContext, filterContext.Exception, _log, HttpStatusCode.NotFound);
                    return;
                case OpahException:
                    filterContext.Result = util.GetErrorResponse(filterContext.HttpContext, filterContext.Exception, _log);
                    return;
                case ApplicationException:
                    filterContext.Result = util.GetErrorResponse(filterContext.HttpContext, filterContext.Exception, _log);
                    return;
                default:
                    filterContext.Result = util.GetErrorResponse(filterContext.HttpContext,
                        "Não foi possível executar a operação, tente novamente mais tarde.", filterContext.Exception, _log);
                    break;
            }
        }
    }
}