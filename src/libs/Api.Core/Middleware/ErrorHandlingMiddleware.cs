using System;
using System.Net;
using System.Threading.Tasks;
using Api.Core.Data.Constants;
using Api.Core.Exceptions;
using Logging.Middleware;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;

namespace Api.Core.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private static Logger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        ///  Handles exceptions.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var errorMessage = ErrorMessages.InternalServerErrorMessage;
            switch (exception)
            {
                case AuthException _:
                    errorMessage = exception.Message;
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ValidationException _:
                case DeserialisationException _:
                    errorMessage = exception.Message;
                    code = HttpStatusCode.BadRequest;
                    break;
                case CommandException _:
                    code = HttpStatusCode.InternalServerError;
                    break;
                case NotFoundException _:
                    errorMessage = exception.Message;
                    code = HttpStatusCode.NotFound;
                    break;
                case PermissionDeniedException _:
                    errorMessage = exception.Message;
                    code = HttpStatusCode.Forbidden;
                    break;
                case ExternalServiceException serviceException:
                    code = serviceException.HttpStatusCode;
                    break;
            }

            var result = JsonConvert.SerializeObject(new {error = errorMessage});
            context.Response.ContentType = MimeTypesConstants.Application.Json;
            context.Response.StatusCode = (int) code;


            await context.Response.WriteAsync(result);

            if (_logger != null)
            {
                await LoggingMiddlewareHelper.LogApiRequestEnd(_logger, context, exception);
            }
        }
    }
}