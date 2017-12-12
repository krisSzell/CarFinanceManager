namespace CarFinanceManager.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserNavigationPropToExpenseDetailsTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ExpenseDetails", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.ExpenseDetails", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ExpenseDetails", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.ExpenseDetails", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}
