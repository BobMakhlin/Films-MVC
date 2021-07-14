using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Films.DAL.MsSqlServer.Repositories
{
    public class FilmsRepository : GenericRepository<Film, int>
    {
        public FilmsRepository(DbContext context) : base(context)
        {
        }
    }
}
