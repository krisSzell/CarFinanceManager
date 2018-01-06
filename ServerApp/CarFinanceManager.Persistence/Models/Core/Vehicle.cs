using CarFinanceManager.Persistence.Models.Accounts;

namespace CarFinanceManager.Persistence.Models.Core
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
