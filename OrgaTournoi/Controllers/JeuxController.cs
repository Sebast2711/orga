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
    public class JeuxController : Controller
    {
        private readonly OrgaTournoiContext _context;

        public JeuxController(OrgaTournoiContext context)
        {
            _context = context;
        }

        // GET: Jeux
        public async Task<IActionResult> Index()
        {
              return View(await _context.Jeu.ToListAsync());
        }

        // return list jeux
        public  List<Jeu> getListJeu()
        {
            return _context.Jeu.ToList();
        }

        // GET: Jeux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jeu == null)
            {
                return NotFound();
            }

            var jeu = await _context.Jeu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jeu == null)
            {
                return NotFound();
            }
            var persos = _context.Entry(jeu).Collection(f => f.Personnages).Query().ToList();


            List<Joueur> joueurs = new List<Joueur>();
            List<Evenement> evenements = new List<Evenement>();

            evenements = _context.Entry(jeu).Collection(f => f.Evenements).Query().ToList();

            jeu.Personnages = persos;


            return View(new JeuTournoiJoueurViewModel(jeu, evenements, joueurs));
        }

        // GET: Jeux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jeux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,DateSortie,Image,Description")] Jeu jeu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jeu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jeu);
        }

        // GET: Jeux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jeu == null)
            {
                return NotFound();
            }

            var jeu = await _context.Jeu.FindAsync(id);
            if (jeu == null)
            {
                return NotFound();
            }
            return View(jeu);
        }

        // POST: Jeux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,DateSortie,Image,Description")] Jeu jeu)
        {
            if (id != jeu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jeu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JeuExists(jeu.Id))
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
            return View(jeu);
        }

        // GET: Jeux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jeu == null)
            {
                return NotFound();
            }

            var jeu = await _context.Jeu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jeu == null)
            {
                return NotFound();
            }

            return View(jeu);
        }

        // POST: Jeux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jeu == null)
            {
                return Problem("Entity set 'OrgaTournoiContext.Jeu'  is null.");
            }
            var jeu = await _context.Jeu.FindAsync(id);
            if (jeu != null)
            {
                _context.Jeu.Remove(jeu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JeuExists(int id)
        {
          return _context.Jeu.Any(e => e.Id == id);
        }
    }
}
