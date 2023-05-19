using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoRRHH.Models;

namespace ProyectoRRHH.Controllers
{
    public class CapacitacionesController : Controller
    {
        private readonly rrhhContext _context;

        public CapacitacionesController(rrhhContext context)
        {
            _context = context;
        }

        // GET: Capacitaciones
        public async Task<IActionResult> Index()
        {
              return View(await _context.capacitaciones.ToListAsync());
        }

        // GET: Capacitaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.capacitaciones == null)
            {
                return NotFound();
            }

            var capacitacione = await _context.capacitaciones
                .FirstOrDefaultAsync(m => m.id == id);
            if (capacitacione == null)
            {
                return NotFound();
            }

            return View(capacitacione);
        }

        // GET: Capacitaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Capacitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descripcion,nivel,fechadesde,fechahasta,institucion")] capacitacione capacitacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capacitacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capacitacione);
        }

        // GET: Capacitaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.capacitaciones == null)
            {
                return NotFound();
            }

            var capacitacione = await _context.capacitaciones.FindAsync(id);
            if (capacitacione == null)
            {
                return NotFound();
            }
            return View(capacitacione);
        }

        // POST: Capacitaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descripcion,nivel,fechadesde,fechahasta,institucion")] capacitacione capacitacione)
        {
            if (id != capacitacione.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capacitacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!capacitacioneExists(capacitacione.id))
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
            return View(capacitacione);
        }

        // GET: Capacitaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.capacitaciones == null)
            {
                return NotFound();
            }

            var capacitacione = await _context.capacitaciones
                .FirstOrDefaultAsync(m => m.id == id);
            if (capacitacione == null)
            {
                return NotFound();
            }

            return View(capacitacione);
        }

        // POST: Capacitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.capacitaciones == null)
            {
                return Problem("Entity set 'rrhhContext.capacitaciones'  is null.");
            }
            var capacitacione = await _context.capacitaciones.FindAsync(id);
            if (capacitacione != null)
            {
                _context.capacitaciones.Remove(capacitacione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool capacitacioneExists(int id)
        {
          return _context.capacitaciones.Any(e => e.id == id);
        }
    }
}
