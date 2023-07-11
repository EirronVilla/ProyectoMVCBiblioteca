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
    public class LibroSociosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibroSociosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LibroSocios
        public async Task<IActionResult> Index()
        {
              return _context.LibroSocio != null ? 
                          View(await _context.LibroSocio.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LibroSocio'  is null.");
        }

		public IActionResult CreateWithBook(Libro? libro = null)
		{
			if (libro == null)
			{
				return RedirectToAction("Create");
			}

            ViewBag.Socios = _context.Socios.ToList();
            ViewBag.Libros = _context.Libros.ToList();
            ViewBag.SelectedBook = libro;
			return View("Create", new LibroSocio());
		}

		// GET: LibroSocios/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LibroSocio == null)
            {
                return NotFound();
            }

            var libroSocio = await _context.LibroSocio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libroSocio == null)
            {
                return NotFound();
            }

            return View(libroSocio);
        }

        // GET: LibroSocios/Create
        public IActionResult Create()
        {
            ViewBag.Socios = _context.Socios.ToList();
            ViewBag.Libros = _context.Libros.ToList();
            return View(new LibroSocio());
        }

        // POST: LibroSocios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SocioId,LibroISBN,FechaPrestamo,FechaRetorno,Estado")] LibroSocio libroSocio)
        {
            if (ModelState.IsValid)
            {
                Libro? libro = !String.IsNullOrEmpty(libroSocio.LibroISBN) ? _context.Libros.Find(libroSocio.LibroISBN) : null;
                if(libro != null && libro.Disponibles > 0)
                {
                    libro.Disponibles--;
                    _context.Add(libroSocio);
                    await _context.SaveChangesAsync();
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(libroSocio);
        }

        // GET: LibroSocios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LibroSocio == null)
            {
                return NotFound();
            }

            var libroSocio = await _context.LibroSocio.FindAsync(id);
            if (libroSocio == null)
            {
                return NotFound();
            }
            return View(libroSocio);
        }

        // POST: LibroSocios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SocioId,LibroISBN,FechaPrestamo,FechaRetorno,Estado")] LibroSocio libroSocio)
        {
            if (id != libroSocio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libroSocio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroSocioExists(libroSocio.Id))
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
            return View(libroSocio);
        }

        // GET: LibroSocios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LibroSocio == null)
            {
                return NotFound();
            }

            var libroSocio = await _context.LibroSocio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libroSocio == null)
            {
                return NotFound();
            }

            return View(libroSocio);
        }

        // POST: LibroSocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            string idValue = Request.Form["prestamo.Id"];
			int id = 0;
            int.TryParse(idValue, out id);
                
			if (_context.LibroSocio == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LibroSocio'  is null.");
            }
            var libroSocio = await _context.LibroSocio.FindAsync(id);
            if (libroSocio != null)
            {
                libroSocio.Estado = false;

                Libro? libro = _context.Libros.Find(libroSocio.LibroISBN);
                if(libro != null)
                {
                    libro.Disponibles++;
                }
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroSocioExists(int id)
        {
          return (_context.LibroSocio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
