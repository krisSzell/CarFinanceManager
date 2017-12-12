using System.Data.Entity.Migrations;

namespace CarFinanceManager.Persistence.Migrations
{
    public partial class AddedExpensesTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        ExpenseCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ExpenseCategoryId);
            
            CreateTable(
                "dbo.ExpenseDetails",
                c => new
                    {
                        ExpenseDetailsID = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                        Category_ExpenseCategoryId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ExpenseDetailsID)
                .ForeignKey("dbo.ExpenseCategories", t => t.Category_ExpenseCategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Category_ExpenseCategoryId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDetails", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ExpenseDetails", "Category_ExpenseCategoryId", "dbo.ExpenseCategories");
            DropIndex("dbo.ExpenseDetails", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ExpenseDetails", new[] { "Category_ExpenseCategoryId" });
            DropTable("dbo.ExpenseDetails");
            DropTable("dbo.ExpenseCategories");
        }
    }
}
