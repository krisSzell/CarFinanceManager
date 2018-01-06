using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFinanceManager.Persistence.Dtos.Core;
using CarFinanceManager.Persistence.Models.Core;

namespace CarFinanceManager.Persistence.Repositories.Interfaces
{
    public interface IVehiclesRepository
    {
        IEnumerable<VehicleDto> GetAllByUsername(string username);
        Vehicle GetSingleById(int id);
        void Add(Vehicle vehicle);
        void Remove(int id);
    }
}
