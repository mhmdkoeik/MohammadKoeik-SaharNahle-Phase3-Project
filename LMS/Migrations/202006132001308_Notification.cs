namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MemberId = c.Int(nullable: false),
                        MessageDate = c.DateTime(),
                        SentByID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SentByID)
                .Index(t => t.MemberId)
                .Index(t => t.SentByID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "SentByID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "MemberId", "dbo.Members");
            DropIndex("dbo.Notifications", new[] { "SentByID" });
            DropIndex("dbo.Notifications", new[] { "MemberId" });
            DropTable("dbo.Notifications");
        }
    }
}
