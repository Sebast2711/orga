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
    public class JoueursController : Controller
    {
        private readonly OrgaTournoiContext _context;

        public JoueursController(OrgaTournoiContext context)
        {
            _context = context;
        }

        // GET: Joueurs
        public async Task<IActionResult> Index(string searchFlag)
        {
            var orgaTournoiContext = _context.Joueur.Include(j => j.Pays);
            var FlagList = new List<string>();

            var players = from m in orgaTournoiContext
                          select m;
            var FlagName = from n in orgaTournoiContext
                           join p in _context.Pays
                           on n.PaysId equals p.Id
                           orderby n.PaysId
                           select p.Nom;

            FlagList.AddRange(FlagName.Distinct());
            ViewBag.searchFlag = new SelectList(FlagList);

            
            foreach (var joueur in players)
            {
                joueur.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries";

            }
            _context.SaveChanges();


            if (!String.IsNullOrEmpty(searchFlag))
            {
                players = players.Where(s => s.Pays.Nom.Contains(searchFlag));
            }

            return View(await players.ToListAsync());
        }
        /*
        public async Task<IActionResult> Index()
        {
            var orgaTournoiContext = _context.Joueur.Include(j => j.Pays);
            return View(await orgaTournoiContext.ToListAsync());
        }
        */
        // GET: Joueurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Joueur == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueur
                .Include(j => j.Pays)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // GET: Joueurs/Create
        public IActionResult Create()
        {
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id");
            return View();
        }

        // POST: Joueurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Pseudo,PaysId,Description,CashprizeTotal,Age")] Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joueur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id", joueur.PaysId);
            return View(joueur);
        }

        // GET: Joueurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Joueur == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueur.FindAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id", joueur.PaysId);
            return View(joueur);
        }

        // POST: Joueurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Pseudo,PaysId,Description,CashprizeTotal,Age")] Joueur joueur)
        {
            if (id != joueur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joueur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoueurExists(joueur.Id))
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
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id", joueur.PaysId);
            return View(joueur);
        }

        // GET: Joueurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Joueur == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueur
                .Include(j => j.Pays)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // POST: Joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Joueur == null)
            {
                return Problem("Entity set 'OrgaTournoiContext.Joueur'  is null.");
            }
            var joueur = await _context.Joueur.FindAsync(id);
            if (joueur != null)
            {
                _context.Joueur.Remove(joueur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JoueurExists(int id)
        {
          return _context.Joueur.Any(e => e.Id == id);
        }
    }
}
