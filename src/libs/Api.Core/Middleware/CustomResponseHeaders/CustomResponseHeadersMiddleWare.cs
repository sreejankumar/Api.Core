using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.Core.Middleware.CustomResponseHeaders
{
    public class CustomResponseHeadersMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly CustomResponseHeadersPolicy _policy;

        public CustomResponseHeadersMiddleWare(RequestDelegate next, CustomResponseHeadersPolicy policy)
        {
            _next = next;
            _policy = policy;
        }

        public async Task Invoke(HttpContext context)
        {
            var headers = context.Response.Headers;

            foreach (var (key, value) in _policy.SetHeaders)
            {
                headers[key] = value;
            }

            foreach (var header in _policy.RemoveHeaders)
            {
                headers.Remove(header);
            }

            await _next(context);
        }
    }
}
