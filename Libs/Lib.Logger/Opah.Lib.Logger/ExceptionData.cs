namespace Opah.Lib.Logger
{
    public class ExceptionData
    {
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public ExceptionData InnerExceptionData { get; set; }
    }
}