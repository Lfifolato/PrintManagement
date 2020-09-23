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
    public class ContadorDeImpressaoController : Controller
    {
        private readonly DataContext _context;

        public ContadorDeImpressaoController(DataContext context)
        {
            _context = context;
        }

        // GET: ContadorDeImpressaos
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.contadorDeImpressaos.Include(c => c.Impressora).Include(c => c.Departamento);
            return View(await dataContext.ToListAsync());
        }

        // GET: ContadorDeImpressaos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contadorDeImpressao = await _context.contadorDeImpressaos
                .Include(c => c.Departamento)
                .Include(c => c.Impressora)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contadorDeImpressao == null)
            {
                return NotFound();
            }

            return View(contadorDeImpressao);
        }

        // GET: ContadorDeImpressaos/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList(_context.Derpartamentos, "Id", "Nome");
            ViewData["IdImpressora"] = new SelectList(_context.Impressoras, "Id", "Nome");
            return View();
        }

        // POST: ContadorDeImpressaos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,IdImpressora,DataLeitura,NomeUsuario,IdDepartamento")] ContadorDeImpressao contadorDeImpressao)
        {
            if (ModelState.IsValid)
            {   
                _context.Add(contadorDeImpressao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Derpartamentos, "Id", "Nome", contadorDeImpressao.IdDepartamento);
            ViewData["IdImpressora"] = new SelectList(_context.Impressoras, "Id", "Nome", contadorDeImpressao.IdImpressora);
            return View(contadorDeImpressao);
        }

        // GET: ContadorDeImpressaos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contadorDeImpressao = await _context.contadorDeImpressaos.FindAsync(id);
            if (contadorDeImpressao == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Derpartamentos, "Id", "Nome", contadorDeImpressao.IdDepartamento);
            ViewData["IdImpressora"] = new SelectList(_context.Impressoras, "Id", "Nome", contadorDeImpressao.IdImpressora);
            return View(contadorDeImpressao);
        }

        // POST: ContadorDeImpressaos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Quantidade,IdImpressora,DataLeitura,NomeUsuario,IdDepartamento")] ContadorDeImpressao contadorDeImpressao)
        {
            if (id != contadorDeImpressao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contadorDeImpressao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContadorDeImpressaoExists(contadorDeImpressao.Id))
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
            ViewData["IdDepartamento"] = new SelectList(_context.Derpartamentos, "Id", "Nome", contadorDeImpressao.IdDepartamento);
            ViewData["IdImpressora"] = new SelectList(_context.Impressoras, "Id", "Nome", contadorDeImpressao.IdImpressora);
            return View(contadorDeImpressao);
        }

        // GET: ContadorDeImpressaos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contadorDeImpressao = await _context.contadorDeImpressaos
                .Include(c => c.Departamento)
                .Include(c => c.Impressora)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contadorDeImpressao == null)
            {
                return NotFound();
            }

            return View(contadorDeImpressao);
        }

        // POST: ContadorDeImpressaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var contadorDeImpressao = await _context.contadorDeImpressaos.FindAsync(id);
            _context.contadorDeImpressaos.Remove(contadorDeImpressao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContadorDeImpressaoExists(long id)
        {
            return _context.contadorDeImpressaos.Any(e => e.Id == id);
        }
    }
}
