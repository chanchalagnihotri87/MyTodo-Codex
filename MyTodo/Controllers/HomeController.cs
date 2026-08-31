using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTodo.Data;
using MyTodo.Models;
using System.Diagnostics;

namespace MyTodo.Controllers
{
    public class HomeController : Controller
    {
        private readonly TodoContext _context;

        public HomeController(TodoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lifeAreas = await _context.LifeAreas
                .AsNoTracking()
                .OrderBy(lifeArea => lifeArea.Name)
                .ToListAsync();

            return View(new HomeIndexViewModel { LifeAreas = lifeAreas });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
