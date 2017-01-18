using System.Data.Entity.Migrations;

namespace Timestamps.DAL.Migrations
{
    public partial class AddNotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Notifications",
                    c => new
                    {
                        Id = c.Int(false, true),
                        DateTime = c.DateTime(false),
                        Type = c.Int(false),
                        ProjectId = c.Int(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, true)
                .Index(t => t.ProjectId);

            CreateTable(
                    "dbo.UserNotifications",
                    c => new
                    {
                        UserId = c.String(false, 128),
                        NotificationId = c.Int(false),
                        IsRead = c.Boolean(false)
                    })
                .PrimaryKey(t => new {t.UserId, t.NotificationId})
                .ForeignKey("dbo.Notifications", t => t.NotificationId, true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "ProjectId", "dbo.Projects");
            DropIndex("dbo.UserNotifications", new[] {"NotificationId"});
            DropIndex("dbo.UserNotifications", new[] {"UserId"});
            DropIndex("dbo.Notifications", new[] {"ProjectId"});
            DropTable("dbo.UserNotifications");
            DropTable("dbo.Notifications");
        }
    }
}