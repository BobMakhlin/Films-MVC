using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.DAL.MsSqlServer.Repositories
{
    public class PhotosRepository : GenericRepository<Photo, int>
    {
        public PhotosRepository(DbContext context) : base(context)
        {
        }
    }
}
