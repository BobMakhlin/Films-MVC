using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Films.BLL.Models;
using Films.BLL.Services.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class FilmsController : Controller
    {
        IGenericService<FilmDto, int> m_filmsService;

        public FilmsController(IGenericService<FilmDto, int> filmsService)
        {
            m_filmsService = filmsService;
        }


        public async Task<IActionResult> Index()
        {
            var films = await m_filmsService.GetAll().ToListAsync();
            return View(films);
        }

        public async Task<IActionResult> EditOrCreate(int id)
        {
            var target = (id == 0) ?
                (new FilmDto()) : (await m_filmsService.GetAsync(id));

            return View(target);
        }
        [HttpPost]
        public async Task<IActionResult> EditOrCreate(FilmDto film)
        {
            if (!ModelState.IsValid)
            {
                return View(film);
            }

            var updatedEmployee = await m_filmsService.UpdateAsync(film);


            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await m_filmsService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
