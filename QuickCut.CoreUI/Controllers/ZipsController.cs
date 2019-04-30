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
    public class ZipsController : Controller
    {
        private readonly QuickCutDataDbContext _context;

        public ZipsController(QuickCutDataDbContext context)
        {
            _context = context;
        }

        // GET: Zips
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zip.ToListAsync());
        }

        // GET: Zips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zip = await _context.Zip
                .FirstOrDefaultAsync(m => m.Zip1 == id);
            if (zip == null)
            {
                return NotFound();
            }

            return View(zip);
        }

        // GET: Zips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Zip1,City,State,Country")] Zip zip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zip);
        }

        // GET: Zips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zip = await _context.Zip.FindAsync(id);
            if (zip == null)
            {
                return NotFound();
            }
            return View(zip);
        }

        // POST: Zips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Zip1,City,State,Country")] Zip zip)
        {
            if (id != zip.Zip1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZipExists(zip.Zip1))
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
            return View(zip);
        }

        // GET: Zips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zip = await _context.Zip
                .FirstOrDefaultAsync(m => m.Zip1 == id);
            if (zip == null)
            {
                return NotFound();
            }

            return View(zip);
        }

        // POST: Zips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zip = await _context.Zip.FindAsync(id);
            _context.Zip.Remove(zip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZipExists(int id)
        {
            return _context.Zip.Any(e => e.Zip1 == id);
        }
    }
}
