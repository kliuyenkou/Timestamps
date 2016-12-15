using System.Data.Entity.Migrations;

namespace Timestamps.DAL.Migrations
{
    public partial class AddHourage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Hourages",
                    c => new
                    {
                        Id = c.Int(false, true),
                        ProjectId = c.Int(false),
                        UserId = c.String(false, 128),
                        WorkDescripton = c.String(maxLength: 128),
                        Date = c.DateTime(false),
                        Hours = c.Double(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Hourages", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hourages", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Hourages", new[] {"UserId"});
            DropIndex("dbo.Hourages", new[] {"ProjectId"});
            DropTable("dbo.Hourages");
        }
    }
}