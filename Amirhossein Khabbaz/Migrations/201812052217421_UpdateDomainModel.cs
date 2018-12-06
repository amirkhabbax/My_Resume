namespace Amirhossein_Khabbaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDomainModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Degree = c.String(nullable: false, maxLength: 255),
                        University = c.String(nullable: false, maxLength: 255),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        MaximumValue = c.Byte(nullable: false),
                        CurrentValue = c.Byte(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 255),
                        Years = c.Byte(nullable: false),
                        ReasonOfDeparture = c.String(nullable: false, maxLength: 255),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Skills", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "Name", c => c.String(nullable: false));
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.Languages");
            DropTable("dbo.Interests");
            DropTable("dbo.Educations");
        }
    }
}
