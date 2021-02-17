using Api.Core.Middleware;
using Api.Core.Middleware.CustomResponseHeaders;
using Logging.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Api.Core.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseMiddleware(this IApplicationBuilder app, CustomResponseHeadersBuilder builder)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            var policy = builder.Build();
            app.UseMiddleware<CustomResponseHeadersMiddleWare>(policy);
        }
    }
}
