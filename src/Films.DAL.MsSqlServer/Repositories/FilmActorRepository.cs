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
    public class FilmActorRepository : GenericRepository<FilmActor, int>
    {
        public FilmActorRepository(DbContext context) : base(context)
        {
        }

        private IQueryable<FilmActor> GetModels() =>
            m_table.Include(item => item.Actor);


        public override IQueryable<FilmActor> GetAll()
        {
            return GetModels();
        }

        public override Task<FilmActor> GetAsync(int id)
        {
            return GetModels()
                .FirstOrDefaultAsync(item => item.Id == id);
        }

        public override IQueryable<FilmActor> Where(Expression<Func<FilmActor, bool>> predicate)
        {
            return GetModels()
                .Where(predicate);
        }
    }
}
