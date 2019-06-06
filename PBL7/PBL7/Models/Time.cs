using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL7.Models
{
    public class Time
    {
        public int TimeId { get; set; }
        public string Nome { get; set; }
        public int PatrocinadorId { get; set; }
        public virtual Patrocinador Patrocinador { get; set; }
        public IList<Jogador> Jogadores { get; set; }
        public int JogadorId { get; set; }
        public Jogador Jogador { get; set; }
        public int NumeroVitorias { get; set; }

    }
}