using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Films.BLL.Models;
using Films.BLL.Services.Common;
using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.BLL.MsSqlServer.Services
{
    public class FilmGenreService : GenericService<FilmGenre, FilmGenreDto, int>
    {
        public FilmGenreService(IGenericRepository<FilmGenre, int> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration
            (
                ce =>
                {
                    ce.CreateMap<FilmGenre, FilmGenreDto>()
                        .ForMember(item => item.GenreName, opts => opts.MapFrom(item => item.Genre.GenreName));

                    ce.CreateMap<FilmGenreDto, FilmGenre>();


                    ce.AddExpressionMapping();
                }
            );
            return new Mapper(mapperConfig);
        }
    }
}
