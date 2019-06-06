namespace PBL7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeJogadors", "Time_TimeId", "dbo.Times");
            DropForeignKey("dbo.TimeJogadors", "Jogador_JogadorId", "dbo.Jogadors");
            DropIndex("dbo.TimeJogadors", new[] { "Time_TimeId" });
            DropIndex("dbo.TimeJogadors", new[] { "Jogador_JogadorId" });
            AddColumn("dbo.Jogadors", "Time_TimeId", c => c.Int());
            AddColumn("dbo.Times", "JogadorId", c => c.Int(nullable: false));
            AddColumn("dbo.Times", "Jogador_JogadorId", c => c.Int());
            AddColumn("dbo.Times", "Jogador_JogadorId1", c => c.Int());
            CreateIndex("dbo.Jogadors", "Time_TimeId");
            CreateIndex("dbo.Times", "Jogador_JogadorId");
            CreateIndex("dbo.Times", "Jogador_JogadorId1");
            AddForeignKey("dbo.Times", "Jogador_JogadorId", "dbo.Jogadors", "JogadorId");
            AddForeignKey("dbo.Jogadors", "Time_TimeId", "dbo.Times", "TimeId");
            AddForeignKey("dbo.Times", "Jogador_JogadorId1", "dbo.Jogadors", "JogadorId");
            DropTable("dbo.TimeJogadors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimeJogadors",
                c => new
                    {
                        Time_TimeId = c.Int(nullable: false),
                        Jogador_JogadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Time_TimeId, t.Jogador_JogadorId });
            
            DropForeignKey("dbo.Times", "Jogador_JogadorId1", "dbo.Jogadors");
            DropForeignKey("dbo.Jogadors", "Time_TimeId", "dbo.Times");
            DropForeignKey("dbo.Times", "Jogador_JogadorId", "dbo.Jogadors");
            DropIndex("dbo.Times", new[] { "Jogador_JogadorId1" });
            DropIndex("dbo.Times", new[] { "Jogador_JogadorId" });
            DropIndex("dbo.Jogadors", new[] { "Time_TimeId" });
            DropColumn("dbo.Times", "Jogador_JogadorId1");
            DropColumn("dbo.Times", "Jogador_JogadorId");
            DropColumn("dbo.Times", "JogadorId");
            DropColumn("dbo.Jogadors", "Time_TimeId");
            CreateIndex("dbo.TimeJogadors", "Jogador_JogadorId");
            CreateIndex("dbo.TimeJogadors", "Time_TimeId");
            AddForeignKey("dbo.TimeJogadors", "Jogador_JogadorId", "dbo.Jogadors", "JogadorId", cascadeDelete: true);
            AddForeignKey("dbo.TimeJogadors", "Time_TimeId", "dbo.Times", "TimeId", cascadeDelete: true);
        }
    }
}
