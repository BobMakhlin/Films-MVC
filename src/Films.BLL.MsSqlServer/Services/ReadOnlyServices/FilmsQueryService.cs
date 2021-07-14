using Films.BLL.Models;
using Films.BLL.Services.Common;
using Films.DAL.MsSqlServer.Models;
using Films.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Films.BLL.MsSqlServer.Services.ReadOnlyServices
{
    public class FilmsQueryService : IQueryService<FilmInfoDto>
    {
        IGenericService<PhotoDto, int> m_photosService;
        IGenericService<FilmGenreDto, int> m_filmGenreService;
        IGenericService<FilmActorDto, int> m_filmActorService;
        IGenericService<FilmDto, int> m_filmsService;

        public FilmsQueryService
        (
            IGenericService<PhotoDto, int> photosService,
            IGenericService<FilmGenreDto, int> filmGenreService,
            IGenericService<FilmActorDto, int> filmActorService,
            IGenericService<FilmDto, int> filmsService
        )
        {
            m_photosService = photosService;
            m_filmGenreService = filmGenreService;
            m_filmActorService = filmActorService;
            m_filmsService = filmsService;
        }


        public IEnumerable<FilmInfoDto> GetAll()
        {
            return
                from film in m_filmsService.GetAll().ToList()

                join filmGenre in m_filmGenreService.GetAll().ToList()
                on film.FilmId equals filmGenre.FilmId
                into filmGenres

                join filmActor in m_filmActorService.GetAll().ToList()
                on film.FilmId equals filmActor.FilmId
                into filmActors

                join photo in m_photosService.GetAll().ToList()
                on film.FilmId equals photo.FilmId
                into filmPhotos

                select new FilmInfoDto
                {
                    FilmId = film.FilmId,
                    FilmName = film.FilmName,
                    FilmYear = film.FilmDate.Year,
                    FilmDescription = film.FilmDescription,

                    Genres = filmGenres.Select(item => item.GenreName),
                    Actors = filmActors.Select(item => item.ActorName),
                    Photos = filmPhotos.Select(item => item.PhotoPath)
                };
        }

        public IEnumerable<FilmInfoDto> Where(Func<FilmInfoDto, bool> predicate)
        {
            return GetAll().Where(predicate);
        }
    }
}
