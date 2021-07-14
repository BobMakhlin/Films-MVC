using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.DAL.MsSqlServer.Repositories
{
    public class ActorsRepository : GenericRepository<Actor, int>
    {
        public ActorsRepository(DbContext context) : base(context)
        {
        }
    }
}
