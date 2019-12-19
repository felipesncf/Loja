using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Models
{
    public class Peca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public Carro Carro { get; set; }
        public int CarroId { get; set; }
        public Galpao Galpao { get; set; }
        public int GalpaoId { get; set; }
        public double Preco { get; set; }

        public Peca()
        {
        }
        public Peca(int id, string nome, Carro carro, int quantidade, Galpao galpao, int IdC, int IdG, double preco)
        {
            Id = id;
            Nome = nome;
            Carro = carro;
            Quantidade = quantidade;
            Galpao = galpao;
            CarroId = IdC;
            GalpaoId = IdG;
            Preco = preco;
        }

        public void Vender(int id, Peca peca)
        {
            if(id==null || peca.Id != id)
            {
            }
            else
            {
                Quantidade--;
            }
        }
    }
}
