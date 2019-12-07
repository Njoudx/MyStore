namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prdprc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Price");
        }
    }
}
