using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Almacen.Models;

namespace Almacen.Controllers
{
    public class ProvedoresController : Controller
    {
        private readonly MyDbContext _context;

        public ProvedoresController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Provedores
        public async Task<IActionResult> Index()
        {
            return View(await _context.provedores.ToListAsync());
        }

        // GET: Provedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provedores = await _context.provedores
                .FirstOrDefaultAsync(m => m.provedorId == id);
            if (provedores == null)
            {
                return NotFound();
            }

            return View(provedores);
        }

        // GET: Provedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("provedorId,empresa,productos,contacto")] Provedores provedores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provedores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provedores);
        }

        // GET: Provedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provedores = await _context.provedores.FindAsync(id);
            if (provedores == null)
            {
                return NotFound();
            }
            return View(provedores);
        }

        // POST: Provedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("provedorId,empresa,productos,contacto")] Provedores provedores)
        {
            if (id != provedores.provedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provedores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvedoresExists(provedores.provedorId))
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
            return View(provedores);
        }

        // GET: Provedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provedores = await _context.provedores
                .FirstOrDefaultAsync(m => m.provedorId == id);
            if (provedores == null)
            {
                return NotFound();
            }

            return View(provedores);
        }

        // POST: Provedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provedores = await _context.provedores.FindAsync(id);
            _context.provedores.Remove(provedores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvedoresExists(int id)
        {
            return _context.provedores.Any(e => e.provedorId == id);
        }
    }
}
