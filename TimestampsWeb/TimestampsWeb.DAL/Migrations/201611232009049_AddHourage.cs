namespace TimestampsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHourage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hourages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        WorkDescripton = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Hours = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hourages", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hourages", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Hourages", new[] { "UserId" });
            DropIndex("dbo.Hourages", new[] { "ProjectId" });
            DropTable("dbo.Hourages");
        }
    }
}
