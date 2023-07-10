using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto1_MVC_AaronVillalobosArguedas.Data;
using Proyecto1_MVC_AaronVillalobosArguedas.Models;

namespace Proyecto1_MVC_AaronVillalobosArguedas.Controllers
{
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SociosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Socios
        public async Task<IActionResult> Index()
        {
              return _context.Socios != null ? 
                          View(await _context.Socios.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Socios'  is null.");
        }

        // GET: Socios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Socios == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // GET: Socios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Socios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cedula,Nombre,Apellidos,FechaRegistro,Activo")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socio);
        }

        // GET: Socios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Socios == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios.FindAsync(id);
            if (socio == null)
            {
                return NotFound();
            }
            return View(socio);
        }

        // POST: Socios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cedula,Nombre,Apellidos,FechaRegistro,Activo")] Socio socio)
        {
            if (id != socio.Cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocioExists(socio.Cedula))
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
            return View(socio);
        }

        // GET: Socios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Socios == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            string id = Request.Form["socio.Cedula"];
            if (_context.Socios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Socios'  is null.");
            }
            var socio = await _context.Socios.FindAsync(id);
            if (socio != null)
            {
                _context.Socios.Remove(socio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocioExists(string id)
        {
          return (_context.Socios?.Any(e => e.Cedula == id)).GetValueOrDefault();
        }
    }
}
