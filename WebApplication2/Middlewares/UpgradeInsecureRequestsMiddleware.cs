using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Middlewares
{
    public class UpgradeInsecureRequestsMiddleware
    {
        private readonly RequestDelegate _next;

        public UpgradeInsecureRequestsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Content-Security-Policy", "upgrade-insecure-requests;");

            await _next(context);
        }
    }
}
