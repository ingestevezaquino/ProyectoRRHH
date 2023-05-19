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
    public class ExpLaboralController : Controller
    {
        private readonly rrhhContext _context;

        public ExpLaboralController(rrhhContext context)
        {
            _context = context;
        }

        // GET: ExpLaboral
        public async Task<IActionResult> Index()
        {
              return View(await _context.explaborals.ToListAsync());
        }

        // GET: ExpLaboral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.explaborals == null)
            {
                return NotFound();
            }

            var explaboral = await _context.explaborals
                .FirstOrDefaultAsync(m => m.id == id);
            if (explaboral == null)
            {
                return NotFound();
            }

            return View(explaboral);
        }

        // GET: ExpLaboral/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpLaboral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,empresa,puestoocupado,fechadesde,fechahasta,salario")] explaboral explaboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(explaboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(explaboral);
        }

        // GET: ExpLaboral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.explaborals == null)
            {
                return NotFound();
            }

            var explaboral = await _context.explaborals.FindAsync(id);
            if (explaboral == null)
            {
                return NotFound();
            }
            return View(explaboral);
        }

        // POST: ExpLaboral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,empresa,puestoocupado,fechadesde,fechahasta,salario")] explaboral explaboral)
        {
            if (id != explaboral.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(explaboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!explaboralExists(explaboral.id))
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
            return View(explaboral);
        }

        // GET: ExpLaboral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.explaborals == null)
            {
                return NotFound();
            }

            var explaboral = await _context.explaborals
                .FirstOrDefaultAsync(m => m.id == id);
            if (explaboral == null)
            {
                return NotFound();
            }

            return View(explaboral);
        }

        // POST: ExpLaboral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.explaborals == null)
            {
                return Problem("Entity set 'rrhhContext.explaborals'  is null.");
            }
            var explaboral = await _context.explaborals.FindAsync(id);
            if (explaboral != null)
            {
                _context.explaborals.Remove(explaboral);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool explaboralExists(int id)
        {
          return _context.explaborals.Any(e => e.id == id);
        }
    }
}
