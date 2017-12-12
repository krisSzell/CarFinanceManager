using System.Data.Entity.Migrations;

namespace CarFinanceManager.Persistence.Migrations
{
    public partial class AddedUserNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserNotificationId = c.Int(nullable: false, identity: true),
                        IsRead = c.Boolean(nullable: false),
                        Notification_NotificationId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserNotificationId)
                .ForeignKey("dbo.Notifications", t => t.Notification_NotificationId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Notification_NotificationId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "Notification_NotificationId", "dbo.Notifications");
            DropIndex("dbo.UserNotifications", new[] { "User_Id" });
            DropIndex("dbo.UserNotifications", new[] { "Notification_NotificationId" });
            DropTable("dbo.UserNotifications");
        }
    }
}
