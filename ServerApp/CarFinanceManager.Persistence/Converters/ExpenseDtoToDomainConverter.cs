using AutoMapper;
using CarFinanceManager.Persistence.Dtos.Core;
using CarFinanceManager.Persistence.Models.Core;

namespace CarFinanceManager.Persistence.Converters
{
    public class ExpenseDtoToDomainConverter : ITypeConverter<ExpenseDto, ExpenseDetails>
    {
        public ExpenseDetails Convert(ExpenseDto source, ExpenseDetails destination, ResolutionContext context)
        {
            return new ExpenseDetails()
            {
                DateCreated = source.DateCreated,
                Cost = source.Cost,
                ExpenseDetailsID = source.Id
            };
        }
    }
}