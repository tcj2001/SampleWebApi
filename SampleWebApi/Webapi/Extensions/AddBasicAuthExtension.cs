using Webapi.Middlewares;

namespace Webapi.Extensions
{
    public static class AddBasicAuthExtension
    {
        public static IApplicationBuilder UseBasicAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthMiddleware>();
        }
    }
}
