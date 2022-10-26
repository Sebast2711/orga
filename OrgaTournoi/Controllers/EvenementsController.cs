using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrgaTournoi.Data;
using OrgaTournoi.Models;

namespace OrgaTournoi.Controllers
{
    public class EvenementsController : Controller
    {
        private readonly OrgaTournoiContext _context;

        public EvenementsController(OrgaTournoiContext context)
        {
            _context = context;
        }

        // GET: Evenements
        public async Task<IActionResult> Index()
        {
            var orgaTournoiContext = _context.Evenement.Include(e => e.Pays).Include(e => e.jeu);
            return View(await orgaTournoiContext.ToListAsync());
        }

        // GET: Evenements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Evenement == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenement
                .Include(e => e.Pays)
                .Include(e => e.jeu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evenement == null)
            {
                return NotFound();
            }


            return View(evenement);
        }

        // GET: Evenements/Create
        public IActionResult Create()
        {
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id");
            ViewData["JeuId"] = new SelectList(_context.Set<Jeu>(), "Id", "Id");
            return View();
        }

        // POST: Evenements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JeuId,Nom,Image,Lieu,PaysId,DateDebut,DateFin,Cashprize")] Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evenement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id", evenement.PaysId);
            ViewData["JeuId"] = new SelectList(_context.Set<Jeu>(), "Id", "Id", evenement.JeuId);
            return View(evenement);
        }

        // GET: Evenements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Evenement == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenement.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id", evenement.PaysId);
            ViewData["JeuId"] = new SelectList(_context.Set<Jeu>(), "Id", "Id", evenement.JeuId);
            return View(evenement);
        }

        // POST: Evenements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JeuId,Nom,Image,Lieu,PaysId,DateDebut,DateFin,Cashprize")] Evenement evenement)
        {
            if (id != evenement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementExists(evenement.Id))
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
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id", evenement.PaysId);
            ViewData["JeuId"] = new SelectList(_context.Set<Jeu>(), "Id", "Id", evenement.JeuId);
            return View(evenement);
        }

        // GET: Evenements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Evenement == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenement
                .Include(e => e.Pays)
                .Include(e => e.jeu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Evenement == null)
            {
                return Problem("Entity set 'OrgaTournoiContext.Evenement'  is null.");
            }
            var evenement = await _context.Evenement.FindAsync(id);
            if (evenement != null)
            {
                _context.Evenement.Remove(evenement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementExists(int id)
        {
          return _context.Evenement.Any(e => e.Id == id);
        }
    }
}
