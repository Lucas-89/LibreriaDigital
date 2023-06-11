using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HerrProgLibreriaDigital.Data;
using HerrProgLibreriaDigital.Models;
using HerrProgLibreriaDigital.ViewModels;

namespace HerrProgLibreriaDigital.Controllers
{
    public class AutorController : Controller
    {
        private readonly AutorContext _context;

        public AutorController(AutorContext context)
        {
            _context = context;
        }

        // GET: Autor
        public async Task<IActionResult> Index(string AutorName)
        {
            var query = from autor in _context.Autor select autor;
            if (!string.IsNullOrEmpty(AutorName))
            {
                query = query.Where(x=> x.Nombre.ToLower().Contains(AutorName.ToLower()));
            }

            var libros = query.Include(x => x.Libros).Select(x =>x.Libros).ToList();

            var model = new AutorViewModel();
            model.Autores = await query.ToListAsync();

              return _context.Autor != null ? 
                          View(model) :
                          Problem("Entity set 'AutorContext.Autor'  is null.");
        }

        // GET: Autor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autor == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.Include(x => x.Libros)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            var viewModel = new AutorDetailViewModel();
            viewModel.Id = autor.Id;
            viewModel.Nombre = autor.Nombre;
            viewModel.Nacionalidad = autor.Nacionalidad;
            viewModel.Libros = autor.Libros != null? autor.Libros : new List<Libro>();

            return View(viewModel);
        }

        // GET: Autor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Nacionalidad,Contemporaneo")] AutorCreateViewModel autor) //recibo un Autor
        {
            // Estoy usando el VM Create a ver si funciona

            var autorrecibido = new Autor(); // lo transformo en Autor
            autorrecibido.Id = autor.Id;
            autorrecibido.Contemporaneo = autor.Contemporaneo;
            autorrecibido.Nombre = autor.Nombre;
            autorrecibido.Nacionalidad = autor.Nacionalidad;

            if (ModelState.IsValid)
            {
                _context.Add(autorrecibido); // Devuelvo VM
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autorrecibido); //esto no sirve pero vamos a probarlo
        }

        // GET: Autor/Edit/5

        /*
        ERROR al querer usar el Edit:
        InvalidOperationException: The model item passed into the ViewDataDictionary is of type 'HerrProgLibreriaDigital.Models.Autor',
         but this ViewDataDictionary instance requires a model item of type 'HerrProgLibreriaDigital.ViewModels.AutorEditViewModel'.
        */

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autor == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Nacionalidad,Contemporaneo")] Autor autor)
        {
            
            if (id != autor.Id)
            {
                return NotFound();
            }                   

            ModelState.Remove("Libros");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor); //esto
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.Id))
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
            return View(autor);
        }

        // GET: Autor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autor == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autor == null)
            {
                return Problem("Entity set 'AutorContext.Autor'  is null.");
            }
            var autor = await _context.Autor.FindAsync(id);
            if (autor != null)
            {
                _context.Autor.Remove(autor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
          return (_context.Autor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
