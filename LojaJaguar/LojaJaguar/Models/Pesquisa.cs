using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Models
{
    public class Pesquisa
    {
        public Peca Peca{ get; set; }

        public Pesquisa()
        {
        }
        public Pesquisa(Peca peca)
        {
            Peca = peca;
        }
    }
}
