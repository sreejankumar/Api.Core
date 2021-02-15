using System;
using System.Net;

namespace Api.Core.Exceptions
{
    public class InfrastructureMissingException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public InfrastructureMissingException(string message, Exception ex, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : base(message, ex)
        {
            HttpStatusCode = httpStatusCode;
        }
        public InfrastructureMissingException(string message, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
