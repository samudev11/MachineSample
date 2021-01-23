using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.SqlPersistence;

namespace VendingMachine.API
{
    public static class SqlPersistenceExtensions
    {
        public static IServiceCollection AddEntityFrameworkCustom(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];

            services.AddDbContext<MachineContext>(options =>
            {
                options.UseSqlServer(connectionString, builder =>
                {
                    builder.MigrationsAssembly(typeof(MachineContext).GetTypeInfo().Assembly.GetName().Name);
                });
            });

            return services;
        }
    }
}