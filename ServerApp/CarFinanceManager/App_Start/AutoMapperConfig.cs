using AutoMapper;
using CarFinanceManager.Persistence.Converters;
using CarFinanceManager.Persistence.Dtos.Core;
using CarFinanceManager.Persistence.Models.Core;

namespace CarFinanceManager
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<ExpenseDto, ExpenseDetails>()
                    .ConvertUsing<ExpenseDtoToDomainConverter>();
                config.CreateMap<VehicleDto, Vehicle>()
                    .ConvertUsing<VehicleDtoToDomainConverter>();
            });
        }
    }
}