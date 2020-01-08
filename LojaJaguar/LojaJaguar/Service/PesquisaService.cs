using LojaJaguar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Service
{
    public class PesquisaService
    {
        private readonly LojaJaguarContext _context;

        public PesquisaService(LojaJaguarContext context)
        {
            _context = context;
        }
        public async Task<List<Pesquisa>> FindByNameAsync(string? name)
        {
            var result = from obj in _context.Pesquisa select obj;

            if (name != null)
            {
                result = result.Where(x => x.Peca.Nome.ToUpper() == name.ToUpper());
            }
            return await result.Include(x => x.Peca).Include(x => x.Peca.Carro).OrderByDescending(x => x.Peca.Preco).ToListAsync();
        }
    }
}
