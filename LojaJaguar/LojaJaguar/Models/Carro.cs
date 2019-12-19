using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public DateTime DataDeChegada { get; set; }
        public ICollection<Peca> Pecas { get; set; } = new List<Peca>();

        public Carro()
        {
        }
        public Carro(int id, string fabricante, string modelo, string cor, int ano, DateTime dataDeChegada)
        {
            Id = id;
            Fabricante = fabricante;
            Modelo = modelo;
            Cor = cor;
            Ano = ano;
            DataDeChegada = dataDeChegada;
        }

        public void AdicionarPeca(Peca peca)
        {
            Pecas.Add(peca);
        }
        public void RemoverPeca(Peca peca)
        {
            Pecas.Remove(peca);
        }
    }
}
