using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickCut.CoreUI.Models;
using Microsoft.EntityFrameworkCore;

namespace QuickCut.CoreUI.Controllers
{
    public class HomeController : Controller
    {
        private QuickCutDataDbContext QuickCutDbContext;

        public HomeController(QuickCutDataDbContext _dbContext)
        {
            QuickCutDbContext = _dbContext;
        }

        public IActionResult Index()
        {
            List<Barber> barbers = QuickCutDbContext.Barber.FromSql($"SELECT * FROM Barber WHERE BarberId IS NOT NULL").ToList();

            ViewBag.barbers = barbers;

            List<Services> services = QuickCutDbContext.Services.Where(s => s.BarberId.Equals(barbers)).ToList();

            ViewBag.services = services;

            return View();
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
