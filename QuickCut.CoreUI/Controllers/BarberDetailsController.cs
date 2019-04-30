using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickCut.CoreUI.Models;

namespace QuickCut.CoreUI.Controllers
{
    public class BarberDetailsController : Controller
    {
        private readonly QuickCutDataDbContext _context;

        public BarberDetailsController(QuickCutDataDbContext context)
        {
            _context = context;
        }

        // GET: BarberDetails
        public async Task<IActionResult> Index()
        {
            var quickCutDataDbContext = _context.BarberDetails.Include(b => b.Barber);
            return View(await quickCutDataDbContext.ToListAsync());
        }

        // GET: BarberDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barberDetails = await _context.BarberDetails
                .Include(b => b.Barber)
                .FirstOrDefaultAsync(m => m.BarberId == id);
            if (barberDetails == null)
            {
                return NotFound();
            }

            return View(barberDetails);
        }

        // GET: BarberDetails/Create
        public IActionResult Create()
        {
            ViewData["BarberId"] = new SelectList(_context.Barber, "BarberId", "BarberAddress");
            return View();
        }

        // POST: BarberDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BarberId,PhoneNumber,OperationHours,DaysOfWeek,PolicyInfo")] BarberDetails barberDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barberDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarberId"] = new SelectList(_context.Barber, "BarberId", "BarberAddress", barberDetails.BarberId);
            return View(barberDetails);
        }

        // GET: BarberDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barberDetails = await _context.BarberDetails.FindAsync(id);
            if (barberDetails == null)
            {
                return NotFound();
            }
            ViewData["BarberId"] = new SelectList(_context.Barber, "BarberId", "BarberAddress", barberDetails.BarberId);
            return View(barberDetails);
        }

        // POST: BarberDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BarberId,PhoneNumber,OperationHours,DaysOfWeek,PolicyInfo")] BarberDetails barberDetails)
        {
            if (id != barberDetails.BarberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barberDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarberDetailsExists(barberDetails.BarberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarberId"] = new SelectList(_context.Barber, "BarberId", "BarberAddress", barberDetails.BarberId);
            return View(barberDetails);
        }

        // GET: BarberDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barberDetails = await _context.BarberDetails
                .Include(b => b.Barber)
                .FirstOrDefaultAsync(m => m.BarberId == id);
            if (barberDetails == null)
            {
                return NotFound();
            }

            return View(barberDetails);
        }

        // POST: BarberDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barberDetails = await _context.BarberDetails.FindAsync(id);
            _context.BarberDetails.Remove(barberDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarberDetailsExists(int id)
        {
            return _context.BarberDetails.Any(e => e.BarberId == id);
        }
    }
}
