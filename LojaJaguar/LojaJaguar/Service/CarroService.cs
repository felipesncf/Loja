using LojaJaguar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Service
{
    public class CarroService
    {
        private readonly LojaJaguarContext _context;

        public CarroService(LojaJaguarContext context)
        {
            _context = context;
        }
        public async Task<List<Carro>> FindAllAsync()
        {
            return await _context.Carro.OrderBy(x => x.Modelo).ToListAsync();
        }
        public async Task<List<Carro>> FindByNameAsync(string name)
        {
            var result = from obj in _context.Carro select obj;
            if (name == null)
            {
                return await _context.Carro.ToListAsync();
            }
            result = result.Where(x => x.Modelo == name);

            return await result.OrderByDescending(x=> x.DataDeChegada).ToListAsync();
        }
    }
}
