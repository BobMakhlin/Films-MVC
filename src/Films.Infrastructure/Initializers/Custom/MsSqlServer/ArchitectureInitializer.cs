using Microsoft.Extensions.DependencyInjection;

using Films.BLL.Models;
using Films.BLL.Services.Common;
using Films.Infrastructure.Initializers.Common;
using Films.Repository.Common;

using Films.BLL.MsSqlServer.Services;
using Films.DAL.MsSqlServer.Models;
using Films.DAL.MsSqlServer.Repositories;
using Films.BLL.MsSqlServer.Services.ReadOnlyServices;

namespace Films.Infrastructure.Initializers.Custom.MsSqlServer
{
    class ArchitectureInitializer : IArchitectureInitializer
    {
        public void InitArchitecture(IServiceCollection services)
        {
            services.AddScoped<IGenericService<ActorDto, int>, ActorsService>();
            services.AddScoped<IGenericRepository<Actor, int>, ActorsRepository>();

            services.AddScoped<IGenericService<FilmActorDto, int>, FilmActorService>();
            services.AddScoped<IGenericRepository<FilmActor, int>, FilmActorRepository>();

            services.AddScoped<IGenericService<FilmGenreDto, int>, FilmGenreService>();
            services.AddScoped<IGenericRepository<FilmGenre, int>, FilmGenreRepository>();

            services.AddScoped<IGenericService<FilmDto, int>, FilmsService>();
            services.AddScoped<IGenericRepository<Film, int>, FilmsRepository>();

            services.AddScoped<IGenericService<GenreDto, int>, GenresService>();
            services.AddScoped<IGenericRepository<Genre, int>, GenresRepository>();

            services.AddScoped<IGenericService<PhotoDto, int>, PhotosService>();
            services.AddScoped<IGenericRepository<Photo, int>, PhotosRepository>();

            services.AddScoped<IGenericService<RatingDto, int>, RatingsService>();
            services.AddScoped<IGenericRepository<Rating, int>, RatingsRepository>();

            services.AddScoped<IQueryService<FilmInfoDto>, FilmsQueryService>();
        }
    }
}
