using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrintManagement.Data;
using PrintManagement.Models;

namespace PrintManagement.Controllers
{
    public class FilialController : Controller
    {
        private readonly DataContext _context;

        public FilialController(DataContext context)
        {
            _context = context;
        }

        // GET: Filial
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filials.ToListAsync());
        }

        // GET: Filial/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filial = await _context.Filials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filial == null)
            {
                return NotFound();
            }

            return View(filial);
        }

        // GET: Filial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filial/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DDD,Nome")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filial);
        }

        // GET: Filial/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filial = await _context.Filials.FindAsync(id);
            if (filial == null)
            {
                return NotFound();
            }
            return View(filial);
        }

        // POST: Filial/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DDD,Nome")] Filial filial)
        {
            if (id != filial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilialExists(filial.Id))
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
            return View(filial);
        }

        // GET: Filial/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filial = await _context.Filials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filial == null)
            {
                return NotFound();
            }

            return View(filial);
        }

        // POST: Filial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var filial = await _context.Filials.FindAsync(id);
            _context.Filials.Remove(filial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilialExists(long id)
        {
            return _context.Filials.Any(e => e.Id == id);
        }
    }
}
