using System;
using System.Net;

namespace Api.Core.Exceptions
{
    public class ExternalServiceException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ExternalServiceException(string message, Exception ex, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : base(message, ex)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ExternalServiceException(string message, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
