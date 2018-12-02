namespace Amirhossein_Khabbaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSkillsToPersonModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Person_Id", c => c.Int());
            CreateIndex("dbo.Skills", "Person_Id");
            AddForeignKey("dbo.Skills", "Person_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Person_Id", "dbo.People");
            DropIndex("dbo.Skills", new[] { "Person_Id" });
            DropColumn("dbo.Skills", "Person_Id");
        }
    }
}
