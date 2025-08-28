namespace GamingTech.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WishList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishList",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserID = c.Int(nullable: false),
                    ProductID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.WishList");
        }
    }
}
