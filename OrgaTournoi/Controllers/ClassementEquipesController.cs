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
    public class ClassementEquipesController : Controller
    {
        private readonly OrgaTournoiContext _context;

        public ClassementEquipesController(OrgaTournoiContext context)
        {
            _context = context;
        }

        // GET: ClassementEquipes
        public async Task<IActionResult> Index()
        {
            var orgaTournoiContext = _context.ClassementEquipe.Include(c => c.Classement).Include(c => c.Equipe);
            return View(await orgaTournoiContext.ToListAsync());
        }

        // GET: ClassementEquipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClassementEquipe == null)
            {
                return NotFound();
            }

            var classementEquipe = await _context.ClassementEquipe
                .Include(c => c.Classement)
                .Include(c => c.Equipe)
                .FirstOrDefaultAsync(m => m.ClassementId == id);
            if (classementEquipe == null)
            {
                return NotFound();
            }

            return View(classementEquipe);
        }

        // GET: ClassementEquipes/Create
        public IActionResult Create()
        {
            ViewData["ClassementId"] = new SelectList(_context.Classement, "Id", "Id");
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id");
            return View();
        }

        // POST: ClassementEquipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassementId,EquipeId,Cashprize,Position,Points")] ClassementEquipe classementEquipe)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(classementEquipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassementId"] = new SelectList(_context.Classement, "Id", "Id", classementEquipe.ClassementId);
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", classementEquipe.EquipeId);
            return View(classementEquipe);
        }

        // GET: ClassementEquipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClassementEquipe == null)
            {
                return NotFound();
            }

            var classementEquipe = await _context.ClassementEquipe.FindAsync(id);
            if (classementEquipe == null)
            {
                return NotFound();
            }
            ViewData["ClassementId"] = new SelectList(_context.Classement, "Id", "Id", classementEquipe.ClassementId);
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", classementEquipe.EquipeId);
            return View(classementEquipe);
        }

        // POST: ClassementEquipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassementId,EquipeId,Cashprize,Position,Points")] ClassementEquipe classementEquipe)
        {
            if (id != classementEquipe.ClassementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classementEquipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassementEquipeExists(classementEquipe.ClassementId))
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
            ViewData["ClassementId"] = new SelectList(_context.Classement, "Id", "Id", classementEquipe.ClassementId);
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", classementEquipe.EquipeId);
            return View(classementEquipe);
        }

        // GET: ClassementEquipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClassementEquipe == null)
            {
                return NotFound();
            }

            var classementEquipe = await _context.ClassementEquipe
                .Include(c => c.Classement)
                .Include(c => c.Equipe)
                .FirstOrDefaultAsync(m => m.ClassementId == id);
            if (classementEquipe == null)
            {
                return NotFound();
            }

            return View(classementEquipe);
        }

        // POST: ClassementEquipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClassementEquipe == null)
            {
                return Problem("Entity set 'OrgaTournoiContext.ClassementEquipe'  is null.");
            }
            var classementEquipe = await _context.ClassementEquipe.FindAsync(id);
            if (classementEquipe != null)
            {
                _context.ClassementEquipe.Remove(classementEquipe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassementEquipeExists(int id)
        {
          return _context.ClassementEquipe.Any(e => e.ClassementId == id);
        }
    }
}
