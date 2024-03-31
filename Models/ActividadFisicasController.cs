using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PAWUNED_EdgarArias_Proyecto1.Models
{
    public class ActividadFisicasController : Controller
    {
        private readonly Proyecto1Context _context;

        public ActividadFisicasController(Proyecto1Context context)
        {
            _context = context;
        }

        // GET: ActividadFisicas
        public async Task<IActionResult> Index()
        {
            var proyecto1Context = _context.ActividadFisicas.Include(a => a.IdUsuarioNavigation);
            return View(await proyecto1Context.ToListAsync());
        }

        // GET: ActividadFisicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividadFisica = await _context.ActividadFisicas
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdRegActividad == id);
            if (actividadFisica == null)
            {
                return NotFound();
            }

            return View(actividadFisica);
        }

        // GET: ActividadFisicas/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: ActividadFisicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegActividad,IdUsuario,TipoActividad,FechaHoraActividad,DuracionMinutos,DistanciaRecorrida,ConsumoCalorico,Comentarios")] ActividadFisica actividadFisica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividadFisica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", actividadFisica.IdUsuario);
            return View(actividadFisica);
        }

        // GET: ActividadFisicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividadFisica = await _context.ActividadFisicas.FindAsync(id);
            if (actividadFisica == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", actividadFisica.IdUsuario);
            return View(actividadFisica);
        }

        // POST: ActividadFisicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegActividad,IdUsuario,TipoActividad,FechaHoraActividad,DuracionMinutos,DistanciaRecorrida,ConsumoCalorico,Comentarios")] ActividadFisica actividadFisica)
        {
            if (id != actividadFisica.IdRegActividad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividadFisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadFisicaExists(actividadFisica.IdRegActividad))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", actividadFisica.IdUsuario);
            return View(actividadFisica);
        }

        // GET: ActividadFisicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividadFisica = await _context.ActividadFisicas
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdRegActividad == id);
            if (actividadFisica == null)
            {
                return NotFound();
            }

            return View(actividadFisica);
        }

        // POST: ActividadFisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividadFisica = await _context.ActividadFisicas.FindAsync(id);
            if (actividadFisica != null)
            {
                _context.ActividadFisicas.Remove(actividadFisica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadFisicaExists(int id)
        {
            return _context.ActividadFisicas.Any(e => e.IdRegActividad == id);
        }
    }
}
