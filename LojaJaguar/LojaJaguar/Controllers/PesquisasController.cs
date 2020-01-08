using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaJaguar.Service;
using Microsoft.AspNetCore.Mvc;

namespace LojaJaguar.Controllers
{
    public class PesquisasController : Controller
    {
        private readonly PesquisaService _pesquisaService;

        public PesquisasController(PesquisaService pesquisaService)
        {
            _pesquisaService = pesquisaService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Pesquisar(string? name)
        {
            //if (pesquisa == null)
            //{
            //    pesquisa = "Digite algo";
            //}

            var result = await _pesquisaService.FindByNameAsync(name);
            return View(result);
        }
    }
}