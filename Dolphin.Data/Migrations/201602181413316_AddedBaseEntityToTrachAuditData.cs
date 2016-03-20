namespace Dolphin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedBaseEntityToTrachAuditData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreatedBy", c => c.String());
            AddColumn("dbo.Users", "CreatedDateUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "LastUpdatedBy", c => c.String());
            AddColumn("dbo.Users", "LastUpdatedDateUtc", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "LastUpdatedDateUtc");
            DropColumn("dbo.Users", "LastUpdatedBy");
            DropColumn("dbo.Users", "CreatedDateUtc");
            DropColumn("dbo.Users", "CreatedBy");
        }
    }
}
