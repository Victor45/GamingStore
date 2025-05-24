namespace GamingTech.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSessions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SessionDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserEmail = c.String(nullable: false),
                        CookieString = c.String(nullable: false),
                        ExpireTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SessionDbTables");
        }
    }
}
