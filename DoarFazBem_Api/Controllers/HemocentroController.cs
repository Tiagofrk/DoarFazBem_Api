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
    public class HemocentroController : Controller
    {
        private readonly AppDbContext _context;

        public HemocentroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Hemocentro
        public async Task<IActionResult> Index()
        {
              return _context.Hemocentro != null ? 
                          View(await _context.Hemocentro.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Hemocentro'  is null.");
        }

        // GET: Hemocentro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hemocentro == null)
            {
                return NotFound();
            }

            var hemocentro = await _context.Hemocentro
                .FirstOrDefaultAsync(m => m.id == id);
            if (hemocentro == null)
            {
                return NotFound();
            }

            return View(hemocentro);
        }

        // GET: Hemocentro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hemocentro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,endereco,cep")] Hemocentro hemocentro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hemocentro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hemocentro);
        }

        // GET: Hemocentro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hemocentro == null)
            {
                return NotFound();
            }

            var hemocentro = await _context.Hemocentro.FindAsync(id);
            if (hemocentro == null)
            {
                return NotFound();
            }
            return View(hemocentro);
        }

        // POST: Hemocentro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,endereco,cep")] Hemocentro hemocentro)
        {
            if (id != hemocentro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hemocentro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HemocentroExists(hemocentro.id))
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
            return View(hemocentro);
        }

        // GET: Hemocentro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hemocentro == null)
            {
                return NotFound();
            }

            var hemocentro = await _context.Hemocentro
                .FirstOrDefaultAsync(m => m.id == id);
            if (hemocentro == null)
            {
                return NotFound();
            }

            return View(hemocentro);
        }

        // POST: Hemocentro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hemocentro == null)
            {
                return Problem("Entity set 'AppDbContext.Hemocentro'  is null.");
            }
            var hemocentro = await _context.Hemocentro.FindAsync(id);
            if (hemocentro != null)
            {
                _context.Hemocentro.Remove(hemocentro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HemocentroExists(int id)
        {
          return (_context.Hemocentro?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
