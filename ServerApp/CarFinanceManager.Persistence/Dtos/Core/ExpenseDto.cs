using System;
using CarFinanceManager.Persistence.Models.Core;

namespace CarFinanceManager.Persistence.Dtos.Core
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime DateCreated { get; set; }
        public string Category { get; set; }
        public int VehicleId { get; set; }
    }
}