namespace Trabalho_Final_MOD_17E.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Carregadors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carregadors",
                c => new
                    {
                        CarregadorID = c.Int(nullable: false, identity: true),
                        Localidade = c.String(nullable: false),
                        Empresa = c.String(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        Preco_por_kWh = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.String(),
                        Longitude = c.String(),
                    })
                .PrimaryKey(t => t.CarregadorID);
            
            CreateTable(
                "dbo.Carregamentoes",
                c => new
                    {
                        CarregamentoID = c.Int(nullable: false, identity: true),
                        data_carregamento = c.DateTime(nullable: false),
                        UtilizadorID = c.Int(nullable: false),
                        CarregadorID = c.Int(nullable: false),
                        kWh = c.Decimal(nullable: false, precision: 18, scale: 2),
                        preco_total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CarregamentoID)
                .ForeignKey("dbo.Carregadors", t => t.CarregadorID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UtilizadorID, cascadeDelete: true)
                .Index(t => t.UtilizadorID)
                .Index(t => t.CarregadorID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false),
                        password = c.String(),
                        perfil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carregamentoes", "UtilizadorID", "dbo.Users");
            DropForeignKey("dbo.Carregamentoes", "CarregadorID", "dbo.Carregadors");
            DropIndex("dbo.Carregamentoes", new[] { "CarregadorID" });
            DropIndex("dbo.Carregamentoes", new[] { "UtilizadorID" });
            DropTable("dbo.Users");
            DropTable("dbo.Carregamentoes");
            DropTable("dbo.Carregadors");
        }
    }
}
