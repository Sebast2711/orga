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
    public class PersonnagesController : Controller
    {
        private readonly OrgaTournoiContext _context;

        public PersonnagesController(OrgaTournoiContext context)
        {
            _context = context;
        }

        // GET: Personnages
        public async Task<IActionResult> Index()
        {
              return View(await _context.Personnage.ToListAsync());
        }

        public async Task<IActionResult> Liste(int? id)
        {
            var jeu = await _context.Jeu
                .FirstOrDefaultAsync(m => m.Id == id);

            var persos = _context.Entry(jeu).Collection(f => f.Personnages).Query().ToList();



            return View(new PersonnageJeuViewModel(jeu, persos));
        }

        // GET: Personnages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personnage == null)
            {
                return NotFound();
            }

            var personnage = await _context.Personnage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnage == null)
            {
                return NotFound();
            }

            return View(personnage);
        }

        // GET: Personnages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personnages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description,Image")] Personnage personnage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personnage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personnage);
        }

        // GET: Personnages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personnage == null)
            {
                return NotFound();
            }

            var personnage = await _context.Personnage.FindAsync(id);
            if (personnage == null)
            {
                return NotFound();
            }
            return View(personnage);
        }

        // POST: Personnages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Description,Image")] Personnage personnage)
        {
            if (id != personnage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnageExists(personnage.Id))
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
            return View(personnage);
        }

        // GET: Personnages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personnage == null)
            {
                return NotFound();
            }

            var personnage = await _context.Personnage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personnage == null)
            {
                return NotFound();
            }

            return View(personnage);
        }

        // POST: Personnages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personnage == null)
            {
                return Problem("Entity set 'OrgaTournoiContext.Personnage'  is null.");
            }
            var personnage = await _context.Personnage.FindAsync(id);
            if (personnage != null)
            {
                _context.Personnage.Remove(personnage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonnageExists(int id)
        {
          return _context.Personnage.Any(e => e.Id == id);
        }
    }
}
