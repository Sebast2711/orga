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
    public class ClassementsController : Controller
    {
        private readonly OrgaTournoiContext _context;

        public ClassementsController(OrgaTournoiContext context)
        {
            _context = context;
        }

        // GET: Classements
        public async Task<IActionResult> Index()
        {
              return View(await _context.Classement.ToListAsync());
        }

        // GET: Classements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classement == null)
            {
                return NotFound();
            }

            var classement = await _context.Classement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classement == null)
            {
                return NotFound();
            }

            return View(classement);
        }

        // GET: Classements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Classement classement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classement);
        }

        // GET: Classements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classement == null)
            {
                return NotFound();
            }

            var classement = await _context.Classement.FindAsync(id);
            if (classement == null)
            {
                return NotFound();
            }
            return View(classement);
        }

        // POST: Classements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Classement classement)
        {
            if (id != classement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassementExists(classement.Id))
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
            return View(classement);
        }

        // GET: Classements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Classement == null)
            {
                return NotFound();
            }

            var classement = await _context.Classement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classement == null)
            {
                return NotFound();
            }

            return View(classement);
        }

        // POST: Classements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classement == null)
            {
                return Problem("Entity set 'OrgaTournoiContext.Classement'  is null.");
            }
            var classement = await _context.Classement.FindAsync(id);
            if (classement != null)
            {
                _context.Classement.Remove(classement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassementExists(int id)
        {
          return _context.Classement.Any(e => e.Id == id);
        }
    }
}
