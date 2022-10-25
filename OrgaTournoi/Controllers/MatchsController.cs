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
    public class MatchsController : Controller
    {
        private readonly OrgaTournoiContext _context;

        public MatchsController(OrgaTournoiContext context)
        {
            _context = context;
        }

        // GET: Matchs
        public async Task<IActionResult> Index()
        {
            var orgaTournoiContext = _context.Match.Include(m => m.Evenement);
            return View(await orgaTournoiContext.ToListAsync());
        }

        // GET: Matchs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Match == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Evenement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matchs/Create
        public IActionResult Create()
        {
            ViewData["EvenementId"] = new SelectList(_context.Evenement, "Id", "Id");
            return View();
        }

        // POST: Matchs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EvenementId,LienStreaming,DateDebut,DateFin,Score")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EvenementId"] = new SelectList(_context.Evenement, "Id", "Id", match.EvenementId);
            return View(match);
        }

        // GET: Matchs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Match == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["EvenementId"] = new SelectList(_context.Evenement, "Id", "Id", match.EvenementId);
            return View(match);
        }

        // POST: Matchs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EvenementId,LienStreaming,DateDebut,DateFin,Score")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
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
            ViewData["EvenementId"] = new SelectList(_context.Evenement, "Id", "Id", match.EvenementId);
            return View(match);
        }

        // GET: Matchs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Match == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Evenement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Match == null)
            {
                return Problem("Entity set 'OrgaTournoiContext.Match'  is null.");
            }
            var match = await _context.Match.FindAsync(id);
            if (match != null)
            {
                _context.Match.Remove(match);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
          return _context.Match.Any(e => e.Id == id);
        }
    }
}
