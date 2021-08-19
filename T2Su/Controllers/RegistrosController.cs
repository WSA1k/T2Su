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
    public class RegistrosController : Controller
    {
        private readonly Context _context;

        public RegistrosController(Context context)
        {
            _context = context;
        }

        // GET: Registros
        public async Task<IActionResult> Index()
        {
            var context = _context.Registros.Include(r => r.Cadastro).Include(r => r.Cate).Include(r => r.Escolha).Include(r => r.Tipomovi);
            return View(await context.ToListAsync());
        }

        // GET: Registros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Cadastro)
                .Include(r => r.Cate)
                .Include(r => r.Escolha)
                .Include(r => r.Tipomovi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registros/Create
        public IActionResult Create()
        {
            ViewData["CadastroId"] = new SelectList(_context.Cadastros, "id", "Status");
            ViewData["CateId"] = new SelectList(_context.Cates, "Id", "Categoria");
            ViewData["EscolhaId"] = new SelectList(_context.Escolhas, "Id", "Tipo");
            ViewData["TipomoviId"] = new SelectList(_context.Tipomovis, "Id", "Tipodemovimentação");
            return View();
        }

        // POST: Registros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cliente,CodigodeContainer,EscolhaId,CadastroId,CateId,TipomoviId,DataInicio,DataDeFim")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastros, "id", "Status", registro.CadastroId);
            ViewData["CateId"] = new SelectList(_context.Cates, "Id", "Categoria", registro.CateId);
            ViewData["EscolhaId"] = new SelectList(_context.Escolhas, "Id", "Tipo", registro.EscolhaId);
            ViewData["TipomoviId"] = new SelectList(_context.Tipomovis, "Id", "Tipodemovimentação", registro.TipomoviId);
            return View(registro);
        }

        // GET: Registros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastros, "id", "Status", registro.CadastroId);
            ViewData["CateId"] = new SelectList(_context.Cates, "Id", "Categoria", registro.CateId);
            ViewData["EscolhaId"] = new SelectList(_context.Escolhas, "Id", "Tipo", registro.EscolhaId);
            ViewData["TipomoviId"] = new SelectList(_context.Tipomovis, "Id", "Tipodemovimentação", registro.TipomoviId);
            return View(registro);
        }

        // POST: Registros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cliente,CodigodeContainer,EscolhaId,CadastroId,CateId,TipomoviId,DataInicio,DataDeFim")] Registro registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registro.Id))
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
            ViewData["CadastroId"] = new SelectList(_context.Cadastros, "id", "Status", registro.CadastroId);
            ViewData["CateId"] = new SelectList(_context.Cates, "Id", "Categoria", registro.CateId);
            ViewData["EscolhaId"] = new SelectList(_context.Escolhas, "Id", "Tipo", registro.EscolhaId);
            ViewData["TipomoviId"] = new SelectList(_context.Tipomovis, "Id", "Tipodemovimentação", registro.TipomoviId);
            return View(registro);
        }

        // GET: Registros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Cadastro)
                .Include(r => r.Cate)
                .Include(r => r.Escolha)
                .Include(r => r.Tipomovi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registro = await _context.Registros.FindAsync(id);
            _context.Registros.Remove(registro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.Id == id);
        }
    }
}
