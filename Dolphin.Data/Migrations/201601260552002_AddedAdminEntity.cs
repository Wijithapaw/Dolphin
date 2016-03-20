namespace Dolphin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedAdminEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
