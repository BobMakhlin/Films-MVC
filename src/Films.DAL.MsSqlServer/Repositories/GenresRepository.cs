using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.DAL.MsSqlServer.Repositories
{
    public class GenresRepository : GenericRepository<Genre, int>
    {
        public GenresRepository(DbContext context) : base(context)
        {
        }
    }
}
