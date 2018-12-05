namespace Amirhossein_Khabbaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePersonModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.People", "CountryPhonePrefix", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.People", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.People", "Email", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Email", c => c.String());
            AlterColumn("dbo.People", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.People", "CountryPhonePrefix", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false));
        }
    }
}
