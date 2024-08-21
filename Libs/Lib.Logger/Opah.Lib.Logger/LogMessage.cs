using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Opah.Lib.Logger
{
    public class LogMessage
    {
        public Guid Id { get; }
        public string CorrelationId { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public LogType LogType { get; }
        public DateTime DateTime { get; }
        public string Message { get; }
        public string Path { get; }

        public LogMessage(string correlationId, string message, LogType logType, string path)
        {
            Id = Guid.NewGuid();
            CorrelationId = correlationId;
            DateTime = DateTime.Now;
            Message = message;
            Path = path;
            LogType = logType;
        }

        public LogMessage(string correlationId, Guid token, string message, LogType logType, string path)
        {
            Id = token;
            CorrelationId = correlationId;
            DateTime = DateTime.Now;
            Message = message;
            Path = path;
            LogType = logType;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}