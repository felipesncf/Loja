using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaJaguar.Models;

namespace LojaJaguar.Models
{
    public class LojaJaguarContext : DbContext
    {
        public LojaJaguarContext (DbContextOptions<LojaJaguarContext> options)
            : base(options)
        {
        }

        public LojaJaguarContext()
        {

        }

        public DbSet<LojaJaguar.Models.Carro> Carro { get; set; }

        public DbSet<LojaJaguar.Models.Galpao> Galpao { get; set; }

        public DbSet<LojaJaguar.Models.Peca> Peca { get; set; }
    }
}
