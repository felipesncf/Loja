using LojaJaguar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Service
{
    public class GalpaoService
    {
        private readonly LojaJaguarContext _context;
        public GalpaoService(LojaJaguarContext context)
        {
            _context = context;
        }
        public async Task<List<Galpao>> FindAllAsync()
        {
            return await _context.Galpao.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
