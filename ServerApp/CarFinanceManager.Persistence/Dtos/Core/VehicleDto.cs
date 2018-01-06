namespace CarFinanceManager.Persistence.Dtos.Core
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public string Username { get; set; }
    }
}