using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL7.Models
{
    public enum Role {TopLaner, Jungler, MidLaner, AdCarry, Support };
    public enum Elo {Ferro, Bronze, Prata, Ouro, Platina, Diamante, Mestre, Desafiante };
    public class Jogador
    {
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Elo Elo { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Time> Times { get; set; }
    }
}