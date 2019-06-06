using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PBL7.Models
{
    public class PBL7Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PBL7Context() : base("name=PBL7Context")
        {
        }

        public System.Data.Entity.DbSet<PBL7.Models.Jogador> Jogadors { get; set; }

        public System.Data.Entity.DbSet<PBL7.Models.Time> Times { get; set; }

        public System.Data.Entity.DbSet<PBL7.Models.Patrocinador> Patrocinadors { get; set; }

        public System.Data.Entity.DbSet<PBL7.Models.Match> Matches { get; set; }
    }
}
