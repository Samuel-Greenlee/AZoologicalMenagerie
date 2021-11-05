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
    public class FavoriteAnimalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoriteAnimalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FavoriteAnimal
        public async Task<IActionResult> Index()
        {
            return View(await _context.FavoriteAnimal.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        // GET: FavoriteAnimal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteAnimal = await _context.FavoriteAnimal
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favoriteAnimal == null)
            {
                return NotFound();
            }

            return View(favoriteAnimal);
        }

        // GET: FavoriteAnimal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavoriteAnimal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Animal,Reason")] FavoriteAnimal favoriteAnimal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteAnimal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favoriteAnimal);
        }

        [Authorize(Roles = "Admin")]
        // GET: FavoriteAnimal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteAnimal = await _context.FavoriteAnimal.SingleOrDefaultAsync(m => m.Id == id);
            if (favoriteAnimal == null)
            {
                return NotFound();
            }
            return View(favoriteAnimal);
        }

        [Authorize(Roles = "Admin")]
        // POST: FavoriteAnimal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Animal,Reason")] FavoriteAnimal favoriteAnimal)
        {
            if (id != favoriteAnimal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteAnimal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteAnimalExists(favoriteAnimal.Id))
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
            return View(favoriteAnimal);
        }

        [Authorize(Roles = "Admin")]
        // GET: FavoriteAnimal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteAnimal = await _context.FavoriteAnimal
                .SingleOrDefaultAsync(m => m.Id == id);
            if (favoriteAnimal == null)
            {
                return NotFound();
            }

            return View(favoriteAnimal);
        }

        [Authorize(Roles = "Admin")]
        // POST: FavoriteAnimal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteAnimal = await _context.FavoriteAnimal.SingleOrDefaultAsync(m => m.Id == id);
            _context.FavoriteAnimal.Remove(favoriteAnimal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteAnimalExists(int id)
        {
            return _context.FavoriteAnimal.Any(e => e.Id == id);
        }
    }
}