//////////////////////////////////////////
// generated AddApplicationExtension.cs //
//////////////////////////////////////////
using Application.Interfaces;
using Application.Services;

namespace Webapi.Extensions
{
    public static class AddApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            return services;
        }
    }
}
