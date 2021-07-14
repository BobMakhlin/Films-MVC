using Films.BLL.Models;
using Films.BLL.Services.Common;
using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.BLL.MsSqlServer.Services
{
    public class ActorsService : GenericService<Actor, ActorDto, int>
    {
        public ActorsService(IGenericRepository<Actor, int> repository) : base(repository)
        {
        }
    }
}
