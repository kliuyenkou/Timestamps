using System.Data.Entity.Migrations;

namespace Timestamps.DAL.Migrations
{
    public partial class AddForeignKeyPropForProject : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Projects", "Creator_Id", "CreatorId");
            RenameIndex("dbo.Projects", "IX_Creator_Id", "IX_CreatorId");
            AlterColumn("dbo.Projects", "Title", c => c.String(false, 128));
            AlterColumn("dbo.Projects", "Description", c => c.String(maxLength: 256));
        }

        public override void Down()
        {
            AlterColumn("dbo.Projects", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Projects", "Title", c => c.String(false, 127));
            RenameIndex("dbo.Projects", "IX_CreatorId", "IX_Creator_Id");
            RenameColumn("dbo.Projects", "CreatorId", "Creator_Id");
        }
    }
}