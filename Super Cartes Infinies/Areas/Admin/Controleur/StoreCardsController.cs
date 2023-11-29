using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Areas.Admin.Controleur
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class StoreCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/StoreCards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StoreCards.OrderBy(x => x.CardId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/StoreCards/Create
        public IActionResult Create()
        {
            ViewData["CardId"] = new SelectList(_context.Cards, "Id", "Id");
            return View();
        }

        // POST: Admin/StoreCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BuyAmount,SellAmount,CardId")] StoreCard storeCard)
        {
            StoreCard dupes = await _context.StoreCards.Where(x => x.CardId == storeCard.CardId).FirstOrDefaultAsync();

            if (ModelState.IsValid && dupes == null)
            {
                _context.Add(storeCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                throw new Exception("Le modele n'est pas valide");
            }

            ViewData["CardId"] = new SelectList(_context.Cards, "Id", "Id", storeCard.CardId);
            return View(storeCard);
        }

        // GET: Admin/StoreCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StoreCards == null)
            {
                return NotFound();
            }

            var storeCard = await _context.StoreCards.FindAsync(id);
            if (storeCard == null)
            {
                return NotFound();
            }
            ViewData["CardId"] = new SelectList(_context.Cards, "Id", "Id", storeCard.CardId);
            return View(storeCard);
        }

        // POST: Admin/StoreCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BuyAmount,SellAmount,CardId")] StoreCard storeCard)
        {
            if (id != storeCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreCardExists(storeCard.Id))
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
            ViewData["CardId"] = new SelectList(_context.Cards, "Id", "Id", storeCard.CardId);
            return View(storeCard);
        }

        // GET: Admin/StoreCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StoreCards == null)
            {
                return NotFound();
            }

            var storeCard = await _context.StoreCards
                .Include(s => s.Card)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeCard == null)
            {
                return NotFound();
            }

            return View(storeCard);
        }

        // POST: Admin/StoreCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StoreCards == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StoreCards'  is null.");
            }
            var storeCard = await _context.StoreCards.FindAsync(id);
            if (storeCard != null)
            {
                _context.StoreCards.Remove(storeCard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreCardExists(int id)
        {
          return (_context.StoreCards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
