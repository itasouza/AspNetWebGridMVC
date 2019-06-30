namespace WebGridUsandoAspNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoIncial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Telefone = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        PrecoDeCusto = c.Single(nullable: false),
                        PrecoDeVenda = c.Single(nullable: false),
                        Medicao = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Categoria_Id = c.Int(),
                        Fornecedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id)
                .ForeignKey("dbo.Fornecedor", t => t.Fornecedor_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Fornecedor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Fornecedor_Id", "dbo.Fornecedor");
            DropForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "Fornecedor_Id" });
            DropIndex("dbo.Produto", new[] { "Categoria_Id" });
            DropTable("dbo.Produto");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Categoria");
        }
    }
}
