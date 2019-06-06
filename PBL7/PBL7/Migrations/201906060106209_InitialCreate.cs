namespace PBL7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogadors",
                c => new
                    {
                        JogadorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Elo = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JogadorId);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        TimeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        PatrocinadorId = c.Int(nullable: false),
                        NumeroVitorias = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimeId)
                .ForeignKey("dbo.Patrocinadors", t => t.PatrocinadorId, cascadeDelete: true)
                .Index(t => t.PatrocinadorId);
            
            CreateTable(
                "dbo.Patrocinadors",
                c => new
                    {
                        PatrocinadorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        AreaAtuacao = c.String(),
                    })
                .PrimaryKey(t => t.PatrocinadorId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        TimeId = c.Int(nullable: false),
                        Premio = c.String(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Times", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.TimeJogadors",
                c => new
                    {
                        Time_TimeId = c.Int(nullable: false),
                        Jogador_JogadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Time_TimeId, t.Jogador_JogadorId })
                .ForeignKey("dbo.Times", t => t.Time_TimeId, cascadeDelete: true)
                .ForeignKey("dbo.Jogadors", t => t.Jogador_JogadorId, cascadeDelete: true)
                .Index(t => t.Time_TimeId)
                .Index(t => t.Jogador_JogadorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "TimeId", "dbo.Times");
            DropForeignKey("dbo.Times", "PatrocinadorId", "dbo.Patrocinadors");
            DropForeignKey("dbo.TimeJogadors", "Jogador_JogadorId", "dbo.Jogadors");
            DropForeignKey("dbo.TimeJogadors", "Time_TimeId", "dbo.Times");
            DropIndex("dbo.TimeJogadors", new[] { "Jogador_JogadorId" });
            DropIndex("dbo.TimeJogadors", new[] { "Time_TimeId" });
            DropIndex("dbo.Matches", new[] { "TimeId" });
            DropIndex("dbo.Times", new[] { "PatrocinadorId" });
            DropTable("dbo.TimeJogadors");
            DropTable("dbo.Matches");
            DropTable("dbo.Patrocinadors");
            DropTable("dbo.Times");
            DropTable("dbo.Jogadors");
        }
    }
}
