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
    public class ContratoDeImpressoraController : Controller
    {
        private readonly DataContext _context;

        public ContratoDeImpressoraController(DataContext context)
        {
            _context = context;
        }

        // GET: ContratoDeImpressoras
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.ContratoDeImpressoras.Include(c => c.Fornecedor);
            return View(await dataContext.ToListAsync());
        }

        // GET: ContratoDeImpressoras/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoDeImpressora = await _context.ContratoDeImpressoras
                .Include(c => c.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratoDeImpressora == null)
            {
                return NotFound();
            }

            return View(contratoDeImpressora);
        }

        // GET: ContratoDeImpressoras/Create
        public IActionResult Create()
        {
            ViewData["Idfornecedor"] = new SelectList(_context.Fornecedors, "Id", "Nome");
            return View();
        }

        // POST: ContratoDeImpressoras/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,IdFornecedor,Franquia,ValorContrato,ValorExcedente,Vigencia,DataInicio")] ContratoDeImpressora contratoDeImpressora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoDeImpressora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idfornecedor"] = new SelectList(_context.Fornecedors, "Id", "Nome", contratoDeImpressora.IdFornecedor);
            return View(contratoDeImpressora);
        }

        // GET: ContratoDeImpressoras/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoDeImpressora = await _context.ContratoDeImpressoras.FindAsync(id);
            if (contratoDeImpressora == null)
            {
                return NotFound();
            }
            ViewData["Idfornecedor"] = new SelectList(_context.Fornecedors, "Id", "Nome", contratoDeImpressora.IdFornecedor);
            return View(contratoDeImpressora);
        }

        // POST: ContratoDeImpressoras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Tipo,IdFornecedor,Franquia,ValorContrato,ValorExcedente,Vigencia,DataInicio")] ContratoDeImpressora contratoDeImpressora)
        {
            if (id != contratoDeImpressora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoDeImpressora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoDeImpressoraExists(contratoDeImpressora.Id))
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
            ViewData["Idfornecedor"] = new SelectList(_context.Fornecedors, "Id", "Nome", contratoDeImpressora.IdFornecedor);
            return View(contratoDeImpressora);
        }

        // GET: ContratoDeImpressoras/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoDeImpressora = await _context.ContratoDeImpressoras
                .Include(c => c.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratoDeImpressora == null)
            {
                return NotFound();
            }

            return View(contratoDeImpressora);
        }

        // POST: ContratoDeImpressoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var contratoDeImpressora = await _context.ContratoDeImpressoras.FindAsync(id);
            _context.ContratoDeImpressoras.Remove(contratoDeImpressora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoDeImpressoraExists(long id)
        {
            return _context.ContratoDeImpressoras.Any(e => e.Id == id);
        }
    }
}
