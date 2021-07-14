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
    public class FilmGenreRepository : GenericRepository<FilmGenre, int>
    {
        public FilmGenreRepository(DbContext context) : base(context)
        {
        }

        private IQueryable<FilmGenre> GetModels() =>
            m_table.Include(item => item.Genre);


        public override IQueryable<FilmGenre> GetAll()
        {
            return GetModels();
        }

        public override Task<FilmGenre> GetAsync(int id)
        {
            return GetModels()
                .FirstOrDefaultAsync(item => item.Id == id);
        }

        public override IQueryable<FilmGenre> Where(Expression<Func<FilmGenre, bool>> predicate)
        {
            return GetModels()
                .Where(predicate);
        }
    }
}
