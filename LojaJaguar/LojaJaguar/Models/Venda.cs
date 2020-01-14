using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public Peca Peca { get; set; }
        public DateTime Data { get; set; }

        public Venda()
        {
        }
        public Venda(int id, int quantidade, Peca peca, DateTime data)
        {
            Id = id;
            Quantidade = quantidade;
            Peca = peca;
            Data = data;
        }
    }
}
