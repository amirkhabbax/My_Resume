namespace Amirhossein_Khabbaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSkillModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "Person_Id", "dbo.People");
            DropIndex("dbo.Skills", new[] { "Person_Id" });
            RenameColumn(table: "dbo.Skills", name: "Person_Id", newName: "PersonId");
            AlterColumn("dbo.Skills", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Skills", "PersonId");
            AddForeignKey("dbo.Skills", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "PersonId", "dbo.People");
            DropIndex("dbo.Skills", new[] { "PersonId" });
            AlterColumn("dbo.Skills", "PersonId", c => c.Int());
            RenameColumn(table: "dbo.Skills", name: "PersonId", newName: "Person_Id");
            CreateIndex("dbo.Skills", "Person_Id");
            AddForeignKey("dbo.Skills", "Person_Id", "dbo.People", "Id");
        }
    }
}
