using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoarFazBem.Models;
using DoarFazBem_Api.Context;

namespace DoarFazBem_Api.Controllers
{
    public class DoadorController : Controller
    {
        private readonly AppDbContext _context;

        public DoadorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Doador
        public async Task<IActionResult> Index()
        {
              return _context.Doador != null ? 
                          View(await _context.Doador.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Doador'  is null.");
        }

        // GET: Doador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doador == null)
            {
                return NotFound();
            }

            var doador = await _context.Doador
                .FirstOrDefaultAsync(m => m.id == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // GET: Doador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tipo_sanguineo,nome_cidade,nome_estado,peso,altura")] Doador doador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doador);
        }

        // GET: Doador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doador == null)
            {
                return NotFound();
            }

            var doador = await _context.Doador.FindAsync(id);
            if (doador == null)
            {
                return NotFound();
            }
            return View(doador);
        }

        // POST: Doador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tipo_sanguineo,nome_cidade,nome_estado,peso,altura")] Doador doador)
        {
            if (id != doador.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoadorExists(doador.id))
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
            return View(doador);
        }

        // GET: Doador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doador == null)
            {
                return NotFound();
            }

            var doador = await _context.Doador
                .FirstOrDefaultAsync(m => m.id == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // POST: Doador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doador == null)
            {
                return Problem("Entity set 'AppDbContext.Doador'  is null.");
            }
            var doador = await _context.Doador.FindAsync(id);
            if (doador != null)
            {
                _context.Doador.Remove(doador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoadorExists(int id)
        {
          return (_context.Doador?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
