//////////////////////////////////////////
// generated AddPersistenceExtension.cs //
//////////////////////////////////////////
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Extensions
{
    public static class AddPersistenceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Name=SqliteDb"));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Name=SqlServerDb"));
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            return services;
        }
    }
}
