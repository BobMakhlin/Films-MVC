using AutoMapper;
using Films.BLL.Models;
using Films.BLL.Services.Common;
using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;

namespace Films.BLL.MsSqlServer.Services
{
    public class FilmsService : GenericService<Film, FilmDto, int>
    {
        public FilmsService(IGenericRepository<Film, int> repository) : base(repository)
        {
        }
    }
}
