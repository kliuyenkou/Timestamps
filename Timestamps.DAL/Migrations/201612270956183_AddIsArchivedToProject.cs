using System.Data.Entity.Migrations;

namespace Timestamps.DAL.Migrations
{
    public partial class AddIsArchivedToProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "IsArchived", c => c.Boolean(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Projects", "IsArchived");
        }
    }
}