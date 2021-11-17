using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AZoologicalMenagerie.Data;
using AZoologicalMenagerie.Models;

namespace AZoologicalMenagerie.Controllers
{
    [Authorize]
    public class FavoriteMerchandiseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoriteMerchandiseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FavoriteMerchandise
        public async Task<IActionResult> Index()
        {
            return View(await _context.FavoriteMerchandise.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        // GET: FavoriteMerchandise/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMerchandise = await _context.FavoriteMerchandise
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favoriteMerchandise == null)
            {
                return NotFound();
            }

            return View(favoriteMerchandise);
        }

        // GET: FavoriteMerchandise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavoriteMerchandise/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Item,ReasonBought")] FavoriteMerchandise favoriteMerchandise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteMerchandise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favoriteMerchandise);
        }

        [Authorize(Roles = "Admin")]
        // GET: FavoriteMerchandise/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMerchandise = await _context.FavoriteMerchandise.SingleOrDefaultAsync(m => m.Id == id);
            if (favoriteMerchandise == null)
            {
                return NotFound();
            }
            return View(favoriteMerchandise);
        }

        [Authorize(Roles = "Admin")]
        // POST: FavoriteMerchandise/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Item,ReasonBought")] FavoriteMerchandise favoriteMerchandise)
        {
            if (id != favoriteMerchandise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteMerchandise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteMerchandiseExists(favoriteMerchandise.Id))
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
            return View(favoriteMerchandise);
        }

        [Authorize(Roles = "Admin")]
        // GET: FavoriteMerchandise/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMerchandise = await _context.FavoriteMerchandise
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favoriteMerchandise == null)
            {
                return NotFound();
            }

            return View(favoriteMerchandise);
        }

        [Authorize(Roles = "Admin")]
        // POST: FavoriteMerchandise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteMerchandise = await _context.FavoriteMerchandise.SingleOrDefaultAsync(m => m.Id == id);
            _context.FavoriteMerchandise.Remove(favoriteMerchandise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteMerchandiseExists(int id)
        {
            return _context.FavoriteMerchandise.Any(e => e.Id == id);
        }
    }
}