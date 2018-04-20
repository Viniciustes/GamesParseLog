namespace GamesParseLog.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileParse",
                c => new
                    {
                        IdFileParse = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        DateFile = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdFileParse);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        IdGame = c.Int(nullable: false, identity: true),
                        NameGame = c.String(),
                    })
                .PrimaryKey(t => t.IdGame);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        IdPlayer = c.Int(nullable: false, identity: true),
                        NamePlayer = c.String(),
                    })
                .PrimaryKey(t => t.IdPlayer);
            
            CreateTable(
                "dbo.Kill",
                c => new
                    {
                        IdKill = c.Int(nullable: false, identity: true),
                        TypeOfDeath = c.Int(nullable: false),
                        IdGame = c.Int(nullable: false),
                        IdPlayer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdKill)
                .ForeignKey("dbo.Game", t => t.IdGame, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.IdPlayer, cascadeDelete: true)
                .Index(t => t.IdGame)
                .Index(t => t.IdPlayer);
            
            CreateTable(
                "dbo.PlayerGame",
                c => new
                    {
                        Player_IdPlayer = c.Int(nullable: false),
                        Game_IdGame = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_IdPlayer, t.Game_IdGame })
                .ForeignKey("dbo.Player", t => t.Player_IdPlayer, cascadeDelete: true)
                .ForeignKey("dbo.Game", t => t.Game_IdGame, cascadeDelete: true)
                .Index(t => t.Player_IdPlayer)
                .Index(t => t.Game_IdGame);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kill", "IdPlayer", "dbo.Player");
            DropForeignKey("dbo.Kill", "IdGame", "dbo.Game");
            DropForeignKey("dbo.PlayerGame", "Game_IdGame", "dbo.Game");
            DropForeignKey("dbo.PlayerGame", "Player_IdPlayer", "dbo.Player");
            DropIndex("dbo.PlayerGame", new[] { "Game_IdGame" });
            DropIndex("dbo.PlayerGame", new[] { "Player_IdPlayer" });
            DropIndex("dbo.Kill", new[] { "IdPlayer" });
            DropIndex("dbo.Kill", new[] { "IdGame" });
            DropTable("dbo.PlayerGame");
            DropTable("dbo.Kill");
            DropTable("dbo.Player");
            DropTable("dbo.Game");
            DropTable("dbo.FileParse");
        }
    }
}
