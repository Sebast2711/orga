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
    public class EquipesController : Controller
    {
        private readonly OrgaTournoiContext _context;

        public EquipesController(OrgaTournoiContext context)
        {
            _context = context;
        }

        // GET: Equipes
        public async Task<IActionResult> Index(string searchFlag, string searchCash)
        {
            var orgaTournoiContext = _context.Equipe.Include(e => e.Pays);
            var FlagList = new List<string>();
            var CashList = new List<string>();
            var GameList = new List<string>();

            var players = from m in orgaTournoiContext
                          select m;
            //find flags name
            var FlagName = from n in orgaTournoiContext
                           join p in _context.Pays
                           on n.PaysId equals p.Id
                           orderby n.PaysId
                           select p.Nom;
            FlagList.AddRange(FlagName.Distinct());
            ViewBag.searchFlag = new SelectList(FlagList);

            //order by cash
            CashList.Add("Ordre Croissant");
            CashList.Add("Ordre Décroissant");
            ViewBag.searchCash = new SelectList(CashList);

            //find game name
            var Gamelist = _context.Equipe.Include(e => e.Pays);

            if (!String.IsNullOrEmpty(searchFlag))
            {
                players = players.Where(s => s.Pays.Nom.Contains(searchFlag));
            }
            if (!String.IsNullOrEmpty(searchCash))
            {
                switch(searchCash)
                {
                    case "Par Ordre Croissant":
                        players = players.OrderBy(x => x.CashpriceTotal);
                        break;
                    case "Par Ordre Décroissant":
                        players = players.OrderByDescending(s => s.CashpriceTotal); 
                        break;
                    default:
                        players = players.OrderBy(s => s.CashpriceTotal);
                        break;
                }      
            }

          



            return View(await players.ToListAsync());
        }/*
        public async Task<IActionResult> Index()
        {
            var orgaTournoiContext = _context.Equipe.Include(e => e.Pays);
            return View(await orgaTournoiContext.ToListAsync());
        }
        */
        // GET: Equipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipe == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe
                .Include(e => e.Pays)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // GET: Equipes/Create
        public IActionResult Create()
        {
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id");
            return View();
        }

        // POST: Equipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Image,Description,CashpriceTotal,PaysId")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id", equipe.PaysId);
            return View(equipe);
        }

        // GET: Equipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipe == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id", equipe.PaysId);
            return View(equipe);
        }

        // POST: Equipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Image,Description,CashpriceTotal,PaysId")] Equipe equipe)
        {
            if (id != equipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipeExists(equipe.Id))
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
            ViewData["PaysId"] = new SelectList(_context.Set<Pays>(), "Id", "Id", equipe.PaysId);
            return View(equipe);
        }

        // GET: Equipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipe == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe
                .Include(e => e.Pays)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipe == null)
            {
                return Problem("Entity set 'OrgaTournoiContext.Equipe'  is null.");
            }
            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe != null)
            {
                _context.Equipe.Remove(equipe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipeExists(int id)
        {
          return _context.Equipe.Any(e => e.Id == id);
        }
    }
}
