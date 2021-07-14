using Films.BLL.Models;
using Films.BLL.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Films.WebUI.Models
{
    public class FilmPoco
    {
        public FilmInfoDto Film { get; set; }
        public bool IsChecked { get; set; }
    }

    public class HomeIndexVm
    {
        string m_currentUserEmail;
        IQueryService<FilmInfoDto> m_filmsService;
        IGenericService<RatingDto, int> m_ratingsService;

        public HomeIndexVm
        (
            IQueryService<FilmInfoDto> filmsService,
            IGenericService<RatingDto, int> ratingsService,
            string currentUserEmail
        )
        {
            m_currentUserEmail = currentUserEmail;
            m_filmsService = filmsService;
            m_ratingsService = ratingsService;
        }

        public List<FilmPoco> Films { get; set; }


        public async Task InitAsync()
        {
            var films = m_filmsService.GetAll().ToList();
            Films = new List<FilmPoco>();


            foreach (var film in films)
            {
                var filmMark = await m_ratingsService
                    .Where
                    (
                       item => (item.FilmId == film.FilmId
                       && item.UserEmail == m_currentUserEmail)
                    )
                    .FirstOrDefaultAsync();


                var filmPoco = new FilmPoco
                {
                    Film = film,
                    IsChecked = filmMark != null
                };

                Films.Add(filmPoco);
            }
        }
    }
}
