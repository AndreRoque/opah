using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Opah.Lib.Logger
{
    public class LogExceptionData
    {
        public Guid Id { get; }
        public string CorrelationId { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public LogType LogType { get; }
        public DateTime DateTime { get; }
        public ExceptionData Data { get; }
        public string Message { get; }
        public string Path { get; }

        public LogExceptionData(string correlationId, Exception exception, LogType logType, string path)
        { 
            Id = Guid.NewGuid();
            CorrelationId = correlationId;
            DateTime = DateTime.Now;
            Path = path;
            LogType = logType;

            Data = ExtractInformation(exception);
        }

        public LogExceptionData(string correlationId, string message, Exception exception, LogType logType, string path)
        {
            Id = Guid.NewGuid();
            CorrelationId = correlationId;
            DateTime = DateTime.Now;
            Path = path;
            LogType = logType;
            Message = message;

            Data = ExtractInformation(exception);
        }

        public LogExceptionData(string correlationId, Guid token, Exception exception, LogType logType, string path)   
        {
            Id = token;
            CorrelationId = correlationId;
            DateTime = DateTime.Now;
            Path = path;
            LogType = logType;

            Data = ExtractInformation(exception);
        }

        public LogExceptionData(string correlationId, Guid token, string message, Exception exception, LogType logType, string path)
        {
            Id = token;
            CorrelationId = correlationId;
            DateTime = DateTime.Now;
            Path = path;
            LogType = logType;
            Message = message;

            Data = ExtractInformation(exception);
        }

        private ExceptionData ExtractInformation(Exception exception)
        {
            var data = new ExceptionData
            {
                Message = exception.Message,
                Source = exception.Source,
                StackTrace = exception.StackTrace
            };

            if (exception.InnerException != null)
            {
                data.InnerExceptionData = ExtractInformation(exception.InnerException);
            }

            return data;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}