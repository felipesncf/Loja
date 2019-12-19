using LojaJaguar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Data
{
    public class SeedingService
    {
        private LojaJaguarContext _context;

        public SeedingService(LojaJaguarContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Carro.Any() || _context.Peca.Any() || _context.Galpao.Any())
            {

            }
        }
    }
}
