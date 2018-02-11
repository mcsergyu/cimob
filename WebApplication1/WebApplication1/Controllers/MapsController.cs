using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cimob.Data;
using Cimob.Models;
using Cimob.Models.ProfileViewModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cimob.Controllers
{

    [Authorize]
    public class MapsController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MapsController(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            this._userManager = _userManager;
            this._context = _context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
        
            var c = from a in _context.Destinations
                    join b in _context.Programs on a.DestinationId equals b.DestinationId
                    select new { a.Cidade,a.Pais, b.Bolsa,b.EndDate, b.Name,b.Vacancies,b.Description,b.StartDate };
                var programs = await c.ToArrayAsync();
            ViewBag.programs = programs;
            return View();
        }


    }
}
