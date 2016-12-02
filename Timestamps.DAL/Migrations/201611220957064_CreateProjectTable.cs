using System.Data.Entity.Migrations;

namespace Timestamps.DAL.Migrations
{
    public partial class CreateProjectTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Creator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .Index(t => t.Creator_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "Creator_Id" });
            DropTable("dbo.Projects");
        }
    }
}
