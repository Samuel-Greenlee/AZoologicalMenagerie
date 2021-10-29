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
    public class UserExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserExperiences
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserExperiences.ToListAsync());
        }

        [Authorize]
        // GET: UserExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userExperiences = await _context.UserExperiences
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userExperiences == null)
            {
                return NotFound();
            }

            return View(userExperiences);
        }

        // GET: UserExperiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Experience")] UserExperiences userExperiences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userExperiences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userExperiences);
        }

        [Authorize]
        // GET: UserExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userExperiences = await _context.UserExperiences.SingleOrDefaultAsync(m => m.Id == id);
            if (userExperiences == null)
            {
                return NotFound();
            }
            return View(userExperiences);
        }

        [Authorize]
        // POST: UserExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Experience")] UserExperiences userExperiences)
        {
            if (id != userExperiences.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userExperiences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExperiencesExists(userExperiences.Id))
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
            return View(userExperiences);
        }

        [Authorize]
        // GET: UserExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userExperiences = await _context.UserExperiences
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userExperiences == null)
            {
                return NotFound();
            }

            return View(userExperiences);
        }

        [Authorize]
        // POST: UserExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userExperiences = await _context.UserExperiences.SingleOrDefaultAsync(m => m.Id == id);
            _context.UserExperiences.Remove(userExperiences);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExperiencesExists(int id)
        {
            return _context.UserExperiences.Any(e => e.Id == id);
        }
    }
}