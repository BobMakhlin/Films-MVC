using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.DAL.MsSqlServer.Repositories
{
    public class RatingsRepository : GenericRepository<Rating, int>
    {
        public RatingsRepository(DbContext context) : base(context)
        {
        }
    }
}
