using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T2Su.Models;

namespace T2Su.Controllers
{
    public class TipomovisController : Controller
    {
        private readonly Context _context;

        public TipomovisController(Context context)
        {
            _context = context;
        }

        // GET: Tipomovis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipomovis.ToListAsync());
        }

        // GET: Tipomovis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipomovi = await _context.Tipomovis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipomovi == null)
            {
                return NotFound();
            }

            return View(tipomovi);
        }

        // GET: Tipomovis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipomovis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipodemovimentação")] Tipomovi tipomovi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipomovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipomovi);
        }

        // GET: Tipomovis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipomovi = await _context.Tipomovis.FindAsync(id);
            if (tipomovi == null)
            {
                return NotFound();
            }
            return View(tipomovi);
        }

        // POST: Tipomovis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipodemovimentação")] Tipomovi tipomovi)
        {
            if (id != tipomovi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipomovi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipomoviExists(tipomovi.Id))
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
            return View(tipomovi);
        }

        // GET: Tipomovis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipomovi = await _context.Tipomovis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipomovi == null)
            {
                return NotFound();
            }

            return View(tipomovi);
        }

        // POST: Tipomovis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipomovi = await _context.Tipomovis.FindAsync(id);
            _context.Tipomovis.Remove(tipomovi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipomoviExists(int id)
        {
            return _context.Tipomovis.Any(e => e.Id == id);
        }
    }
}
