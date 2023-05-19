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
    public class CandidatosController : Controller
    {
        private readonly rrhhContext _context;

        public CandidatosController(rrhhContext context)
        {
            _context = context;
        }

        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
            var rrhhContext = await _context.candidatos
                .Include(c => c.competencias)
                .Include(c => c.capacitacionesNavigation)
                .Include(c => c.departamentoNavigation)
                .Include(c => c.explaboralNavigation)
                .Include(c => c.puestoaspiraNavigation)
                .ToListAsync();
            return View(rrhhContext);
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.candidatos == null)
            {
                return NotFound();
            }

            var candidato = await _context.candidatos
                .Include(c => c.competencias)
                .Include(c => c.capacitacionesNavigation)
                .Include(c => c.departamentoNavigation)
                .Include(c => c.explaboralNavigation)
                .Include(c => c.puestoaspiraNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            ViewData["competencias"] = new SelectList(_context.competencias, "id", "descripcion");
            ViewData["capacitaciones"] = new SelectList(_context.capacitaciones, "descripcion", "descripcion");
            ViewData["departamento"] = new SelectList(_context.departamentos, "departamento1", "departamento1");
            ViewData["explaboral"] = new SelectList(_context.explaborals, "empresa", "empresa");
            ViewData["puestoaspira"] = new SelectList(_context.puestos, "nombre", "nombre");
            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,cedula,nombre,puestoaspira,departamento,salarioaspira,competencias,capacitaciones,explaboral,recomendadopor")] candidato candidato)
        {
            if (ModelState.IsValid)
            {
                var competenciasIds = Request.Form["competencias"].Select(x => int.Parse(x)).ToArray();
                var competencias = _context.competencias.Where(x => competenciasIds.Contains(x.id)).ToList();
                candidato.competencias = competencias;

                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["competencias"] = new SelectList(_context.competencias, "id", "descripcion", candidato.competencias);
            ViewData["capacitaciones"] = new SelectList(_context.capacitaciones, "descripcion", "descripcion", candidato.capacitaciones);
            ViewData["departamento"] = new SelectList(_context.departamentos, "departamento1", "departamento1", candidato.departamento);
            ViewData["explaboral"] = new SelectList(_context.explaborals, "empresa", "empresa", candidato.explaboral);
            ViewData["puestoaspira"] = new SelectList(_context.puestos, "nombre", "nombre", candidato.puestoaspira);
            return View(candidato);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.candidatos == null)
            {
                return NotFound();
            }

            var candidato = await _context.candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            ViewData["capacitaciones"] = new SelectList(_context.capacitaciones, "descripcion", "descripcion", candidato.capacitaciones);
            ViewData["departamento"] = new SelectList(_context.departamentos, "departamento1", "departamento1", candidato.departamento);
            ViewData["explaboral"] = new SelectList(_context.explaborals, "empresa", "empresa", candidato.explaboral);
            ViewData["puestoaspira"] = new SelectList(_context.puestos, "nombre", "nombre", candidato.puestoaspira);
            return View(candidato);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,cedula,nombre,puestoaspira,departamento,salarioaspira,capacitaciones,explaboral,recomendadopor")] candidato candidato)
        {
            if (id != candidato.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!candidatoExists(candidato.id))
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
            ViewData["capacitaciones"] = new SelectList(_context.capacitaciones, "descripcion", "descripcion", candidato.capacitaciones);
            ViewData["departamento"] = new SelectList(_context.departamentos, "departamento1", "departamento1", candidato.departamento);
            ViewData["explaboral"] = new SelectList(_context.explaborals, "empresa", "empresa", candidato.explaboral);
            ViewData["puestoaspira"] = new SelectList(_context.puestos, "nombre", "nombre", candidato.puestoaspira);
            return View(candidato);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.candidatos == null)
            {
                return NotFound();
            }

            var candidato = await _context.candidatos
                .Include(c => c.capacitacionesNavigation)
                .Include(c => c.departamentoNavigation)
                .Include(c => c.explaboralNavigation)
                .Include(c => c.puestoaspiraNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.candidatos == null)
            {
                return Problem("Entity set 'rrhhContext.candidatos'  is null.");
            }
            var candidato = await _context.candidatos.FindAsync(id);
            if (candidato != null)
            {
                _context.candidatos.Remove(candidato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool candidatoExists(int id)
        {
          return _context.candidatos.Any(e => e.id == id);
        }
    }
}
