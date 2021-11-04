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
    public class AnimalSuggestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalSuggestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnimalSuggestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimalSuggestions.ToListAsync());
        }

        [Authorize]
        // GET: AnimalSuggestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalSuggestions = await _context.AnimalSuggestions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (animalSuggestions == null)
            {
                return NotFound();
            }

            return View(animalSuggestions);
        }

        // GET: AnimalSuggestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalSuggestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Suggestion")] AnimalSuggestions animalSuggestions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalSuggestions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalSuggestions);
        }

        [Authorize]
        // GET: AnimalSuggestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalSuggestions = await _context.AnimalSuggestions.SingleOrDefaultAsync(m => m.Id == id);
            if (animalSuggestions == null)
            {
                return NotFound();
            }
            return View(animalSuggestions);
        }

        [Authorize]
        // POST: AnimalSuggestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Suggestion")] AnimalSuggestions animalSuggestions)
        {
            if (id != animalSuggestions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalSuggestions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalSuggestionsExists(animalSuggestions.Id))
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
            return View(animalSuggestions);
        }

        [Authorize]
        // GET: AnimalSuggestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalSuggestions = await _context.AnimalSuggestions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (animalSuggestions == null)
            {
                return NotFound();
            }

            return View(animalSuggestions);
        }

        [Authorize]
        // POST: AnimalSuggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalSuggestions = await _context.AnimalSuggestions.SingleOrDefaultAsync(m => m.Id == id);
            _context.AnimalSuggestions.Remove(animalSuggestions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalSuggestionsExists(int id)
        {
            return _context.AnimalSuggestions.Any(e => e.Id == id);
        }
    }
}