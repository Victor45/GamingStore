namespace GamingTech.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Category");
        }
    }
}
