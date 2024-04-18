using IR.Infrastructure.Context.Read;
using IR.Infrastructure.Context.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IR.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
        {
            //Adds Read context
            services.AddDbContext<ReadContext>(options =>
            {
                ConfigureSqlConnectionBehavior(configuration, options);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });

            //Adds Write context
            services.AddDbContext<WriteContext>(options =>
            {
                ConfigureSqlConnectionBehavior(configuration, options);
            });


            return services;
        }

        /// <summary>
        /// Configures SQL connection properties.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="options"></param>
        private static void ConfigureSqlConnectionBehavior(IConfigurationRoot configuration, DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString"), sql =>
            {
                sql.CommandTimeout(30);
                sql.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
        }
    }
}
