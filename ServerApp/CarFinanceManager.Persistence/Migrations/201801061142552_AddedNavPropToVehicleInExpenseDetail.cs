namespace CarFinanceManager.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNavPropToVehicleInExpenseDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseDetails", "Vehicle_VehicleId", c => c.Int());
            CreateIndex("dbo.ExpenseDetails", "Vehicle_VehicleId");
            AddForeignKey("dbo.ExpenseDetails", "Vehicle_VehicleId", "dbo.Vehicles", "VehicleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDetails", "Vehicle_VehicleId", "dbo.Vehicles");
            DropIndex("dbo.ExpenseDetails", new[] { "Vehicle_VehicleId" });
            DropColumn("dbo.ExpenseDetails", "Vehicle_VehicleId");
        }
    }
}
