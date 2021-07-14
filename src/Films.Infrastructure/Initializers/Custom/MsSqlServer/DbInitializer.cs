using Films.DAL.MsSqlServer.DataAccess;
using Films.DAL.MsSqlServer.Models;
using Films.Infrastructure.Initializers.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Films.Infrastructure.Initializers.Custom.MsSqlServer
{
    class DbInitializer : IDbInitializer
    {
        IConfiguration m_configuration;

        public DbInitializer(IConfiguration configuration)
        {
            m_configuration = configuration;
        }


        public void InitDb(IServiceCollection services)
        {
            services.AddScoped<DbContext, FilmsDbContext>();


            var conString = m_configuration.GetConnectionString("MsSqlServerFilms");
            services.AddDbContext<FilmsDbContext>(opt =>
            {
                opt.UseSqlServer(conString);
            });
        }
    }
}
