using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Films.BLL.Models;
using Films.BLL.Services.Common;
using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Films.BLL.MsSqlServer.Services
{
    public class FilmActorService : GenericService<FilmActor, FilmActorDto, int>
    {
        public FilmActorService(IGenericRepository<FilmActor, int> repository) : base(repository)
        {
        }

        protected override IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration
            (
                ce =>
                {
                    ce.CreateMap<FilmActor, FilmActorDto>()
                        .ForMember(item => item.ActorName, opts => opts.MapFrom(item => item.Actor.ActorName));

                    ce.CreateMap<FilmActorDto, FilmActor>();


                    ce.AddExpressionMapping();
                }
            );
            return new Mapper(mapperConfig);
        }
    }
}
