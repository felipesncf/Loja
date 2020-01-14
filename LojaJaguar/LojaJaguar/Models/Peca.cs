using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Models
{
    public class Peca
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Quantidade { get; set; }
        public Carro Carro { get; set; }

        [Display(Name = "Carro")]
        public int CarroId { get; set; }
        public Galpao Galpao { get; set; }

        [Display(Name = "Galpão")]
        public int GalpaoId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Preço")]
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

        public void Vender(int quant, Peca peca)
        {
            peca.Quantidade -= quant;
        }
    }
}
