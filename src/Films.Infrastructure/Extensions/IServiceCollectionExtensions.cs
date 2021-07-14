using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Films.Infrastructure.Initializers.Common;

using Films.Infrastructure.Initializers.Custom.MsSqlServer;


namespace Films.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void InitArchitecture(this IServiceCollection services)
        {
            IArchitectureInitializer initializer = new ArchitectureInitializer();

            initializer.InitArchitecture(services);
        }

        public static void InitDb(this IServiceCollection services, IConfiguration config)
        {
            IDbInitializer initializer = new DbInitializer(config);

            initializer.InitDb(services);
        }
    }
}
