namespace CarWash.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotificationsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        ExpenseDetails_ExpenseDetailsID = c.Int(),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.ExpenseDetails", t => t.ExpenseDetails_ExpenseDetailsID)
                .Index(t => t.ExpenseDetails_ExpenseDetailsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "ExpenseDetails_ExpenseDetailsID", "dbo.ExpenseDetails");
            DropIndex("dbo.Notifications", new[] { "ExpenseDetails_ExpenseDetailsID" });
            DropTable("dbo.Notifications");
        }
    }
}
