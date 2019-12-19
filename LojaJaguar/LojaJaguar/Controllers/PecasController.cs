using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaJaguar.Models;
using LojaJaguar.Service;
using LojaJaguar.Models.ViewModels;
using LojaJaguar.Service.Exceptions;
using System.Diagnostics;

namespace LojaJaguar.Controllers
{
    public class PecasController : Controller
    {
        private readonly LojaJaguarContext _context;
        private readonly PecaService _pecaService;
        private readonly CarroService _carroService;
        private readonly GalpaoService _galpaoService;

        public PecasController(LojaJaguarContext context, PecaService pecaService, CarroService carroService, GalpaoService galpaoService)
        {
            _context = context;
            _pecaService = pecaService;
            _carroService = carroService;
            _galpaoService = galpaoService;
        }

        // GET: Pecas
        public async Task<IActionResult> Index()
        {
            var lojaJaguarContext = _context.Peca.Include(p => p.Carro).Include(p => p.Galpao);
            return View(await lojaJaguarContext.ToListAsync());
        }

        // GET: Pecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Peca
                .Include(p => p.Carro)
                .Include(p => p.Galpao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peca == null)
            {
                return NotFound();
            }

            return View(peca);
        }

        // GET: Pecas/Create
        public async Task<IActionResult> Create()
        {
            var carros = await _carroService.FindAllAsync();
            var galpoes = await _galpaoService.FindAllAsync();
            var viewModel = new PecaViewModel { Carros = carros, Galpoes = galpoes };
            return View(viewModel);
        }

        // POST: Pecas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Quantidade,CarroId,GalpaoId")] Peca peca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Id", peca.CarroId);
            ViewData["GalpaoId"] = new SelectList(_context.Galpao, "Id", "Id", peca.GalpaoId);
            return View(peca);
        }

        // GET: Pecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id não foi fornecido" }); ;
            }
            var obj = await _pecaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id não encontrado" });
            }

            var carros = await _carroService.FindAllAsync();
            var galpoes = await _galpaoService.FindAllAsync();
            var viewModel = new PecaViewModel { Carros = carros, Galpoes = galpoes };

            return View(viewModel);
        }

        // POST: Pecas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Quantidade,CarroId,GalpaoId")] Peca peca)
        {
            if (!ModelState.IsValid)
            {
                var carros = await _carroService.FindAllAsync();
                var galpoes = await _galpaoService.FindAllAsync();
                var viewModel = new PecaViewModel { Carros = carros, Galpoes = galpoes };

                return View(viewModel);
            }
            if (id != peca.Id)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id não corresponde" });
            }
            try
            {
                await _pecaService.UpdateAsync(peca);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { mensagem = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { mensagem = e.Message });
            }
        }

        // GET: Pecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Peca
                .Include(p => p.Carro)
                .Include(p => p.Galpao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peca == null)
            {
                return NotFound();
            }

            return View(peca);
        }

        // POST: Pecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peca = await _context.Peca.FindAsync(id);
            _context.Peca.Remove(peca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PecaExists(int id)
        {
            return _context.Peca.Any(e => e.Id == id);
        }
        public IActionResult Error(string mensagem)
        {
            var viewModel = new ErrorViewModel
            {
                Mensagem = mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
