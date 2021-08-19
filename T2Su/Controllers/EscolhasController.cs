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
    public class EscolhasController : Controller
    {
        private readonly Context _context;

        public EscolhasController(Context context)
        {
            _context = context;
        }

        // GET: Escolhas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Escolhas.ToListAsync());
        }

        // GET: Escolhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolha = await _context.Escolhas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escolha == null)
            {
                return NotFound();
            }

            return View(escolha);
        }

        // GET: Escolhas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escolhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo")] Escolha escolha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escolha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escolha);
        }

        // GET: Escolhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolha = await _context.Escolhas.FindAsync(id);
            if (escolha == null)
            {
                return NotFound();
            }
            return View(escolha);
        }

        // POST: Escolhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo")] Escolha escolha)
        {
            if (id != escolha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escolha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolhaExists(escolha.Id))
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
            return View(escolha);
        }

        // GET: Escolhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolha = await _context.Escolhas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escolha == null)
            {
                return NotFound();
            }

            return View(escolha);
        }

        // POST: Escolhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escolha = await _context.Escolhas.FindAsync(id);
            _context.Escolhas.Remove(escolha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolhaExists(int id)
        {
            return _context.Escolhas.Any(e => e.Id == id);
        }
    }
}
