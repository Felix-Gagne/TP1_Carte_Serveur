using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Areas.Admin.Controleur
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class StartingCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartingCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/StartingCards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StartingCards.Include(s => s.Card);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/StartingCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StartingCards == null)
            {
                return NotFound();
            }

            var startingCards = await _context.StartingCards
                .Include(s => s.Card)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (startingCards == null)
            {
                return NotFound();
            }

            return View(startingCards);
        }

        // GET: Admin/StartingCards/Create
        public IActionResult Create()
        {
            ViewBag.ExistingCards = _context.Cards.ToList();
            return View();
        }

        // POST: Admin/StartingCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CardId")] StartingCards startingCards)
        {
            if (ModelState.IsValid)
            {
                var selectedCard = _context.Cards.Find(startingCards.CardId);
                startingCards.Card = selectedCard;
                _context.StartingCards.Add(startingCards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(startingCards);
        }

        // GET: Admin/StartingCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StartingCards == null)
            {
                return NotFound();
            }

            var startingCards = await _context.StartingCards.FindAsync(id);
            if (startingCards == null)
            {
                return NotFound();
            }
            ViewData["CardId"] = new SelectList(_context.Cards, "Id", "Id", startingCards.CardId);
            return View(startingCards);
        }

        // POST: Admin/StartingCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CardId")] StartingCards startingCards)
        {
            if (id != startingCards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(startingCards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StartingCardsExists(startingCards.Id))
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
            ViewData["CardId"] = new SelectList(_context.Cards, "Id", "Id", startingCards.CardId);
            return View(startingCards);
        }

        // GET: Admin/StartingCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StartingCards == null)
            {
                return NotFound();
            }

            var startingCards = await _context.StartingCards
                .Include(s => s.Card)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (startingCards == null)
            {
                return NotFound();
            }

            return View(startingCards);
        }

        // POST: Admin/StartingCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StartingCards == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StartingCards'  is null.");
            }
            var startingCards = await _context.StartingCards.FindAsync(id);
            if (startingCards != null)
            {
                _context.StartingCards.Remove(startingCards);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StartingCardsExists(int id)
        {
          return (_context.StartingCards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
