using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Models.ViewModels
{
    public class PecaViewModel
    {
        public Peca Peca { get; set; }
        public ICollection<Galpao> Galpoes { get; set; }
        public ICollection<Carro> Carros { get; set; }
    }
}
