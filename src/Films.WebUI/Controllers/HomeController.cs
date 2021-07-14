using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Films.WebUI.Models;
using Films.BLL.Services.Common;
using Films.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace Films.WebUI.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        IQueryService<FilmInfoDto> m_filmInfoService;
        IGenericService<RatingDto, int> m_ratingsService;
        #endregion

        public HomeController
        (
            IQueryService<FilmInfoDto> filmInfoService,
            IGenericService<RatingDto, int> ratingsService
        )
        {
            m_filmInfoService = filmInfoService;
            m_ratingsService = ratingsService;
        }


        public async Task<IActionResult> Index()
        {
            var vm = new HomeIndexVm
            (
                m_filmInfoService, 
                m_ratingsService, 
                User.Identity.Name
            );
            await vm.InitAsync();


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> MarkFilm(int id)
        {
            try
            {
                var username = User.Identity.Name;

                var selectedFilms = await m_ratingsService
                    .Where(item => item.UserEmail == username)
                    .ToListAsync();

                if (selectedFilms.Count >= 2)
                {
                    return StatusCode(409);
                }


                var rating = new RatingDto
                {
                    FilmId = id,
                    UserEmail = username
                };

                await m_ratingsService.AddAsync(rating);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UnmarkFilm(int id)
        {
            try
            {
                var target = await m_ratingsService
                    .Where
                    (
                        item => (item.FilmId == id
                        && item.UserEmail == User.Identity.Name)
                    )
                    .FirstOrDefaultAsync();

                await m_ratingsService.DeleteAsync(target.RatingId);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
