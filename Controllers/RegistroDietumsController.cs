using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAWUNED_EdgarArias_Proyecto1.Models;

namespace PAWUNED_EdgarArias_Proyecto1.Controllers
{
    public class RegistroDietumsController : Controller
    {
        private readonly Proyecto1Context _context;

        public RegistroDietumsController(Proyecto1Context context)
        {
            _context = context;
        }

        // GET: RegistroDietums
        public async Task<IActionResult> Index()
        {
            var proyecto1Context = _context.RegistroDieta.Include(r => r.IdUsuarioNavigation);
            return View(await proyecto1Context.ToListAsync());
        }

        // GET: RegistroDietums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDietum = await _context.RegistroDieta
                .Include(r => r.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdRegDieta == id);
            if (registroDietum == null)
            {
                return NotFound();
            }

            return View(registroDietum);
        }

        // GET: RegistroDietums/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: RegistroDietums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegDieta,IdUsuario,FechaComida,TipoComida,AlimentosConsumidos,CaloriasTotales,Comentarios")] RegistroDietum registroDietum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroDietum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", registroDietum.IdUsuario);
            return View(registroDietum);
        }

        // GET: RegistroDietums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDietum = await _context.RegistroDieta.FindAsync(id);
            if (registroDietum == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", registroDietum.IdUsuario);
            return View(registroDietum);
        }

        // POST: RegistroDietums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegDieta,IdUsuario,FechaComida,TipoComida,AlimentosConsumidos,CaloriasTotales,Comentarios")] RegistroDietum registroDietum)
        {
            if (id != registroDietum.IdRegDieta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroDietum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroDietumExists(registroDietum.IdRegDieta))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", registroDietum.IdUsuario);
            return View(registroDietum);
        }

        // GET: RegistroDietums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDietum = await _context.RegistroDieta
                .Include(r => r.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdRegDieta == id);
            if (registroDietum == null)
            {
                return NotFound();
            }

            return View(registroDietum);
        }

        // POST: RegistroDietums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroDietum = await _context.RegistroDieta.FindAsync(id);
            if (registroDietum != null)
            {
                _context.RegistroDieta.Remove(registroDietum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroDietumExists(int id)
        {
            return _context.RegistroDieta.Any(e => e.IdRegDieta == id);
        }
    }
}
