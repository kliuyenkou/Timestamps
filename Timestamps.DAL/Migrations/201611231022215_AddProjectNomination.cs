using System.Data.Entity.Migrations;

namespace Timestamps.DAL.Migrations
{
    public partial class AddProjectNomination : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.ProjectNominations",
                    c => new
                    {
                        Id = c.Int(false, true),
                        ProjectId = c.Int(false),
                        UserId = c.String(false, 128)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ProjectNominations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectNominations", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectNominations", new[] {"UserId"});
            DropIndex("dbo.ProjectNominations", new[] {"ProjectId"});
            DropTable("dbo.ProjectNominations");
        }
    }
}