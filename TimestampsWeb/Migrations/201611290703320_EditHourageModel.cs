namespace TimestampsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditHourageModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hourages", "WorkDescription", c => c.String(maxLength: 128));
            DropColumn("dbo.Hourages", "WorkDescripton");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hourages", "WorkDescripton", c => c.String(maxLength: 128));
            DropColumn("dbo.Hourages", "WorkDescription");
        }
    }
}
