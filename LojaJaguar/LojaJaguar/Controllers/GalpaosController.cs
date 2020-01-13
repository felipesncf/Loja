using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaJaguar.Models;
using Microsoft.AspNetCore.Authorization;

namespace LojaJaguar.Controllers
{
    public class GalpaosController : Controller
    {
        private readonly LojaJaguarContext _context;

        public GalpaosController(LojaJaguarContext context)
        {
            _context = context;
        }

        // GET: Galpaos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Galpao.ToListAsync());
        }

        // GET: Galpaos/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galpao = await _context.Galpao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galpao == null)
            {
                return NotFound();
            }

            return View(galpao);
        }

        // GET: Galpaos/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Galpaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Galpao galpao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(galpao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(galpao);
        }

        // GET: Galpaos/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galpao = await _context.Galpao.FindAsync(id);
            if (galpao == null)
            {
                return NotFound();
            }
            return View(galpao);
        }

        // POST: Galpaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Galpao galpao)
        {
            if (id != galpao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galpao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalpaoExists(galpao.Id))
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
            return View(galpao);
        }

        // GET: Galpaos/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galpao = await _context.Galpao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galpao == null)
            {
                return NotFound();
            }

            return View(galpao);
        }

        // POST: Galpaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galpao = await _context.Galpao.FindAsync(id);
            _context.Galpao.Remove(galpao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalpaoExists(int id)
        {
            return _context.Galpao.Any(e => e.Id == id);
        }
    }
}
