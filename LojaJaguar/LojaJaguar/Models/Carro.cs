using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [StringLength(25, MinimumLength = 2, ErrorMessage = "O tamanho do campo deve ser entre {2} e {1}")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "O tamanho do campo deve ser entre {2} e {1}")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "O tamanho do campo deve ser entre {2} e {1}")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
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
