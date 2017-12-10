namespace CarWash.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAssociationBetweenUsersAndVehiclesOwned : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        ProductionYear = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Vehicles", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Vehicles");
        }
    }
}
