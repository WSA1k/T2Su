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
    public class CatesController : Controller
    {
        private readonly Context _context;

        public CatesController(Context context)
        {
            _context = context;
        }

        // GET: Cates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cates.ToListAsync());
        }

        // GET: Cates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cate = await _context.Cates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        // GET: Cates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Categoria")] Cate cate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cate);
        }

        // GET: Cates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cate = await _context.Cates.FindAsync(id);
            if (cate == null)
            {
                return NotFound();
            }
            return View(cate);
        }

        // POST: Cates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Categoria")] Cate cate)
        {
            if (id != cate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CateExists(cate.Id))
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
            return View(cate);
        }

        // GET: Cates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cate = await _context.Cates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }

        // POST: Cates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cate = await _context.Cates.FindAsync(id);
            _context.Cates.Remove(cate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CateExists(int id)
        {
            return _context.Cates.Any(e => e.Id == id);
        }
    }
}
