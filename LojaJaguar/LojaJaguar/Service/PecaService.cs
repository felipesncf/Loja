using LojaJaguar.Models;
using LojaJaguar.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Service
{
    public class PecaService
    {
        private readonly LojaJaguarContext _context;
        public PecaService(LojaJaguarContext context)
        {
            _context = context;
        }

        public async Task<List<Peca>> FindAllAsync()
        {
            return await _context.Peca.ToListAsync();
        }

        public async Task InsertAsync(Peca obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Peca> FindByIdAsync(int id)
        {
            return await _context.Peca.Include(obj => obj.Carro).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            _context.Peca.Remove(await _context.Peca.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Peca obj)
        {
            if (!await _context.Peca.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
