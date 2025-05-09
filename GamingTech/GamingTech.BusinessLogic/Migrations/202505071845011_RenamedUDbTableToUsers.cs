namespace GamingTech.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedUDbTableToUsers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UDbTables", newName: "Users");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Users", newName: "UDbTables");
        }
    }
}
