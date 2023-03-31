using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MojeAplikace.Data;
using MojeAplikace.Models;

namespace MojeAplikace.Controllers
{
    public class sachistasController : Controller
    {
        private readonly MojeAplikaceContext _context;

        public sachistasController(MojeAplikaceContext context)
        {
            _context = context;
        }


        // GET: sachistas
        public async Task<IActionResult> Index()
        {
              return _context.sachista != null ? 
                          View(await _context.sachista.ToListAsync()) :
                          Problem("Entity set 'MojeAplikaceContext.sachista'  is null.");
        }

        // GET: sachistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sachista == null)
            {
                return NotFound();
            }

            var sachista = await _context.sachista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sachista == null)
            {
                return NotFound();
            }

            return View(sachista);
        }

        // GET: sachistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sachistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Elo,Name,PripravenHrat,ZacatekHrani")] sachista sachista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sachista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sachista);
        }

        // GET: sachistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sachista == null)
            {
                return NotFound();
            }

            var sachista = await _context.sachista.FindAsync(id);
            if (sachista == null)
            {
                return NotFound();
            }
            return View(sachista);
        }

        // POST: sachistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Elo,Name,PripravenHrat,ZacatekHrani")] sachista sachista)
        {
            if (id != sachista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sachista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sachistaExists(sachista.Id))
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
            return View(sachista);
        }

        // GET: sachistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sachista == null)
            {
                return NotFound();
            }

            var sachista = await _context.sachista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sachista == null)
            {
                return NotFound();
            }

            return View(sachista);
        }

        // POST: sachistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sachista == null)
            {
                return Problem("Entity set 'MojeAplikaceContext.sachista'  is null.");
            }
            var sachista = await _context.sachista.FindAsync(id);
            if (sachista != null)
            {
                _context.sachista.Remove(sachista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sachistaExists(int id)
        {
          return (_context.sachista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
