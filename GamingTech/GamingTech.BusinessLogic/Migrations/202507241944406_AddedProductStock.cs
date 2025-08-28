namespace GamingTech.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Stock");
        }
    }
}
