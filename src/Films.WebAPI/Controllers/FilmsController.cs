using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Films.BLL.Models;
using Films.BLL.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        #region Fields
        IQueryService<FilmInfoDto> m_filmInfoService;
        #endregion

        public FilmsController
        (
            IQueryService<FilmInfoDto> filmInfoService
        )
        {
            m_filmInfoService = filmInfoService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<FilmInfoDto>> GetFilms()
        {
            var films = m_filmInfoService
                .GetAll();

            return Ok(films);
        }

        [HttpGet("ByName/{name}")]
        public ActionResult<IEnumerable<FilmInfoDto>> GetFilmsByName(string name)
        {
            var films = m_filmInfoService
                .Where
                (
                    item => item.FilmName.ToLower().Contains(name.ToLower())
                );

            return Ok(films);
        }

        [HttpGet("ByGenre/{genre}")]
        public ActionResult<IEnumerable<FilmInfoDto>> GetFilmsByGenre(string genre)
        {
            var films = m_filmInfoService
                .Where
                (
                    item => item.Genres.Any(g => g.Contains(genre))
                );

            return Ok(films);
        }

        [HttpGet("ByActor/{name}")]
        public ActionResult<IEnumerable<FilmInfoDto>> GetFilmsByActor(string name)
        {
            var films = m_filmInfoService
                .Where
                (
                    item => item.Actors.Any(a => a.Contains(name))
                );

            return Ok(films);
        }
    }
}
