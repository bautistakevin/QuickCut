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
            List<BarberViewModel> bs = new List<BarberViewModel>();

            List<Barber> barbers = QuickCutDbContext.Barber.FromSql($"SELECT * FROM Barber WHERE BarberId IS NOT NULL").ToList();

            foreach(Barber barber in barbers)
            {
                BarberViewModel temp = new BarberViewModel();
                temp.services = QuickCutDbContext.Services.Where(s => s.BarberId.Equals(barber.BarberId)).ToList();
                temp.barber = barber;
                bs.Add(temp);
            }

            ViewBag.BarberServices = bs;

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
