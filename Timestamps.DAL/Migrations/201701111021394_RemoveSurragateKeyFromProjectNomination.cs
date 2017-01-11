namespace Timestamps.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSurragateKeyFromProjectNomination : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProjectNominations");
            AddPrimaryKey("dbo.ProjectNominations", new[] { "ProjectId", "UserId" });
            DropColumn("dbo.ProjectNominations", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectNominations", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ProjectNominations");
            AddPrimaryKey("dbo.ProjectNominations", "Id");
        }
    }
}
