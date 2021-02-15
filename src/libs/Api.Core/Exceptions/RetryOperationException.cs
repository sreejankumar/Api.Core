namespace Api.Core.Exceptions
{
    public class RetryOperationException: System.Exception
    {
        public string FullStackTrace { get; set; }
        public RetryOperationException(string message, System.Exception ex) : base(message, ex)
        {
            FullStackTrace = ex.StackTrace;
        }
        public RetryOperationException(string message) : base(message)
        {
            
        }
    }
}