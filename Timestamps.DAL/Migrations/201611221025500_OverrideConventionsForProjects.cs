using System.Data.Entity.Migrations;

namespace Timestamps.DAL.Migrations
{
    public partial class OverrideConventionsForProjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] {"Creator_Id"});
            AlterColumn("dbo.Projects", "Title", c => c.String(false, 127));
            AlterColumn("dbo.Projects", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Projects", "Creator_Id", c => c.String(false, 128));
            CreateIndex("dbo.Projects", "Creator_Id");
            AddForeignKey("dbo.Projects", "Creator_Id", "dbo.AspNetUsers", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] {"Creator_Id"});
            AlterColumn("dbo.Projects", "Creator_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projects", "Description", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
            CreateIndex("dbo.Projects", "Creator_Id");
            AddForeignKey("dbo.Projects", "Creator_Id", "dbo.AspNetUsers", "Id");
        }
    }
}