using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaJaguar.Models
{
    public class Galpao
    {   
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "O tamanho do campo deve ser entre {2} e {1}")]
        [Required(ErrorMessage ="Este campo é obrigatório")]
        public string Nome { get; set; }
        public ICollection<Peca> Pecas { get; set; } = new List<Peca>();


        public Galpao()
        {
        }
        public Galpao(int id, string nome, ICollection<Peca> pecas)
        {
            Id = id;
            Nome = nome;
            Pecas = pecas;
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
