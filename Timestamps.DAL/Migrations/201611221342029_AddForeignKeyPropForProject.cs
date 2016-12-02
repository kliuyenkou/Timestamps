using System.Data.Entity.Migrations;

namespace Timestamps.DAL.Migrations
{
    public partial class AddForeignKeyPropForProject : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "Creator_Id", newName: "CreatorId");
            RenameIndex(table: "dbo.Projects", name: "IX_Creator_Id", newName: "IX_CreatorId");
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Projects", "Description", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false, maxLength: 127));
            RenameIndex(table: "dbo.Projects", name: "IX_CreatorId", newName: "IX_Creator_Id");
            RenameColumn(table: "dbo.Projects", name: "CreatorId", newName: "Creator_Id");
        }
    }
}
