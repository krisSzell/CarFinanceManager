using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFinanceManager.Persistence.Dtos.Core;
using CarFinanceManager.Persistence.Models.Core;
using CarFinanceManager.Persistence.Repositories.Interfaces;

namespace CarFinanceManager.Persistence.Repositories
{
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly ApplicationDbContext _context;

        public VehiclesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<VehicleDto> GetAllByUsername(string username)
        {
            return _context.Vehicles
                .Where(v => v.User.UserName == username)
                .Select(v => new VehicleDto
                    {
                        Id = v.VehicleId,
                        Make = v.Make,
                        Model = v.Model,
                        ProductionYear = v.ProductionYear,
                        Mileage = v.Mileage,
                        Username = username
                    })
                .ToList();
        }

        public void Add(Vehicle vehicle)
        {
            if (_context.Vehicles.Find(vehicle.VehicleId) == null)
                _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
