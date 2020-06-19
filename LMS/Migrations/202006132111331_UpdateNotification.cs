namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNotification : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "Message", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
