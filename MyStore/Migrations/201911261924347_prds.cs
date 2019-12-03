namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compatibilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        DeviceId = c.Int(nullable: false),
                        DeviceName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        PTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.PTypes", t => t.PTypeId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.PTypeId);
            
            CreateTable(
                "dbo.PTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PTypeId", "dbo.PTypes");
            DropForeignKey("dbo.Compatibilities", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "PTypeId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Compatibilities", new[] { "ProductId" });
            DropTable("dbo.PTypes");
            DropTable("dbo.Products");
            DropTable("dbo.Compatibilities");
            DropTable("dbo.Devices");
        }
    }
}
