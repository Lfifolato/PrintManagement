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
    public class ImpressoraController : Controller
    {
        private readonly DataContext _context;

        public ImpressoraController(DataContext context)
        {
            _context = context;
        }

        // GET: Impressora
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Impressoras.Include(i => i.ContratoDeImpressora).Include(i => i.Departamento).Include(i => i.Filial).Include(i => i.Modelo);
            return View(await dataContext.ToListAsync());
        }

        // GET: Impressora/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impressora = await _context.Impressoras
                .Include(i => i.ContratoDeImpressora)
                .Include(i => i.Departamento)
                .Include(i => i.Filial)
                .Include(i => i.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impressora == null)
            {
                return NotFound();
            }

            return View(impressora);
        }

        // GET: Impressora/Create
        public IActionResult Create()
        {
            ViewData["IdContrato"] = new SelectList(_context.ContratoDeImpressoras, "Id", "Tipo");
            ViewData["IdDepartamento"] = new SelectList(_context.Derpartamentos, "Id", "Nome");
            ViewData["IdFilial"] = new SelectList(_context.Filials, "Id", "Nome");
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nome");
            return View();
        }

        // POST: Impressora/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Serial,IdFilial,IdModelo,IdDepartamento,IdContrato")] Impressora impressora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(impressora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdContrato"] = new SelectList(_context.ContratoDeImpressoras, "Id", "Tipo", impressora.IdContrato);
            ViewData["IdDepartamento"] = new SelectList(_context.Derpartamentos, "Id", "Nome", impressora.IdDepartamento);
            ViewData["IdFilial"] = new SelectList(_context.Filials, "Id", "Nome", impressora.IdFilial);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nome", impressora.IdModelo);
            return View(impressora);
        }

        // GET: Impressora/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impressora = await _context.Impressoras.FindAsync(id);
            if (impressora == null)
            {
                return NotFound();
            }
            ViewData["IdContrato"] = new SelectList(_context.ContratoDeImpressoras, "Id", "Tipo", impressora.IdContrato);
            ViewData["IdDepartamento"] = new SelectList(_context.Derpartamentos, "Id", "Nome", impressora.IdDepartamento);
            ViewData["IdFilial"] = new SelectList(_context.Filials, "Id", "Nome", impressora.IdFilial);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nome", impressora.IdModelo);
            return View(impressora);
        }

        // POST: Impressora/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Serial,IdFilial,IdModelo,IdDepartamento,IdContrato")] Impressora impressora)
        {
            if (id != impressora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(impressora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImpressoraExists(impressora.Id))
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
            ViewData["IdContrato"] = new SelectList(_context.ContratoDeImpressoras, "Id", "Tipo", impressora.IdContrato);
            ViewData["IdDepartamento"] = new SelectList(_context.Derpartamentos, "Id", "Nome", impressora.IdDepartamento);
            ViewData["IdFilial"] = new SelectList(_context.Filials, "Id", "Nome", impressora.IdFilial);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nome", impressora.IdModelo);
            return View(impressora);
        }

        // GET: Impressora/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impressora = await _context.Impressoras
                .Include(i => i.ContratoDeImpressora)
                .Include(i => i.Departamento)
                .Include(i => i.Filial)
                .Include(i => i.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impressora == null)
            {
                return NotFound();
            }

            return View(impressora);
        }

        // POST: Impressora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var impressora = await _context.Impressoras.FindAsync(id);
            _context.Impressoras.Remove(impressora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImpressoraExists(long id)
        {
            return _context.Impressoras.Any(e => e.Id == id);
        }
    }
}
