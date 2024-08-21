using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using CorrelationId.Abstractions;
using Opah.Lib.MicrosservicoBase.Exception;

namespace Opah.Lib.Logger
{
    public class OpahLogger : IOpahLogger
    {
        #region Private Fields

        private readonly string _path;

        private readonly ICorrelationContextAccessor _correlationContextAccessor;

        private readonly ILogger _logger;

        #endregion Private Fields

        #region Public Constructors

        public OpahLogger(ICorrelationContextAccessor correlationContextAccessor, IConfiguration config)
        {
            _path = config["log-path"];

            ValidateConfig(_path);

            _correlationContextAccessor = correlationContextAccessor;

            _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(_path,
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private void ValidateConfig(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new OpahException("O caminho do log não foi definido!");
            }
        }

        #endregion Public Constructors

        #region Public Methods

        public Guid Log(LogType logType, Exception exception)
        {
            var log = new LogExceptionData(_correlationContextAccessor.CorrelationContext.CorrelationId, exception, logType, _path);
            ThreadPool.QueueUserWorkItem(task => _logger.Write(GetLogLevel(logType), log.Serialize()));

            return log.Id;
        }

        public Guid Log(LogType logType, string message)
        {
            var log = new LogMessage(_correlationContextAccessor.CorrelationContext.CorrelationId, message, logType, _path);
            ThreadPool.QueueUserWorkItem(task => _logger.Write(GetLogLevel(logType), log.Serialize()));

            return log.Id;
        }

        public void Log(LogType logType, Exception exception, Guid token)
        {
            var log = new LogExceptionData(_correlationContextAccessor.CorrelationContext.CorrelationId, token, exception, logType, _path);
            ThreadPool.QueueUserWorkItem(task => _logger.Write(GetLogLevel(logType), log.Serialize()));
        }

        public void Log(LogType logType, string message, Guid token)
        {
            var log = new LogMessage(_correlationContextAccessor.CorrelationContext.CorrelationId, token, message, logType, _path);
            ThreadPool.QueueUserWorkItem(task => _logger.Write(GetLogLevel(logType), log.Serialize()));
        }

        public Guid Log(LogType logType, string message, Exception exception)
        {
            var log = new LogExceptionData(_correlationContextAccessor.CorrelationContext.CorrelationId, message, exception, logType, _path);
            ThreadPool.QueueUserWorkItem(task => _logger.Write(GetLogLevel(logType), log.Serialize()));

            return log.Id;
        }

        public void Log(LogType logType, string message, Exception exception, Guid token)
        {
            var log = new LogExceptionData(_correlationContextAccessor.CorrelationContext.CorrelationId, token, message, exception, logType, _path);
            ThreadPool.QueueUserWorkItem(task => _logger.Write(GetLogLevel(logType), log.Serialize()));
        }

        #endregion Public Methods

        #region Private Methods

        private LogEventLevel GetLogLevel(LogType logType)
        {
            if (logType == LogType.Debug)
            {
                return LogEventLevel.Debug;
            }

            if (logType == LogType.Error)
            {
                return LogEventLevel.Error;
            }

            if (logType == LogType.Fatal)
            {
                return LogEventLevel.Fatal;
            }

            if (logType == LogType.Information)
            {
                return LogEventLevel.Information;
            }

            return LogEventLevel.Warning;
        }

        #endregion Private Methods
    }
}