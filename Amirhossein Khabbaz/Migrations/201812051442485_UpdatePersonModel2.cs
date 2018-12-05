namespace Amirhossein_Khabbaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePersonModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "LinkediN", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Github", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "Gitlab", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "twitter", c => c.String(maxLength: 255));
            AddColumn("dbo.People", "facebook", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "facebook");
            DropColumn("dbo.People", "twitter");
            DropColumn("dbo.People", "Gitlab");
            DropColumn("dbo.People", "Github");
            DropColumn("dbo.People", "LinkediN");
        }
    }
}
