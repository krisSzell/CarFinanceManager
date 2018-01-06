using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarFinanceManager.Persistence.Dtos.Core;
using CarFinanceManager.Persistence.Models.Core;

namespace CarFinanceManager.Persistence.Converters
{
    public class VehicleDtoToDomainConverter : ITypeConverter<VehicleDto, Vehicle>
    {
        public Vehicle Convert(VehicleDto source, Vehicle destination, ResolutionContext context)
        {
            return new Vehicle()
            {
                VehicleId = source.Id,
                Make = source.Make,
                Model = source.Model,
                ProductionYear = source.ProductionYear,
                Mileage = source.Mileage
            };
        }
    }
}
