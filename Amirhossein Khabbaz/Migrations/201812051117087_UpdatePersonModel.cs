namespace Amirhossein_Khabbaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePersonModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "PersonId", "dbo.People");
            DropIndex("dbo.Skills", new[] { "PersonId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Skills", "PersonId");
            AddForeignKey("dbo.Skills", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
