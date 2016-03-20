namespace Dolphin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedAdminAsDonor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsAdmin");
        }
    }
}
