namespace GamingTech.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Level");
        }
    }
}
