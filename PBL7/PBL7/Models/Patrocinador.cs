using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL7.Models
{
    public class Patrocinador
    {
        public int PatrocinadorId { get; set; }
        public string Nome { get; set; }
        public string AreaAtuacao { get; set; }
        public virtual ICollection<Time> Times { get; set; }
    }
}