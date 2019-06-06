using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL7.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int TimeId { get; set; }
        public virtual Time Time { get; set; }
        public string Premio { get; set; }
    }
}