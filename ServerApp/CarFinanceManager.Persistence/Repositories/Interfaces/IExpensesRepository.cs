using System.Collections.Generic;
using CarFinanceManager.Persistence.Dtos.Core;
using CarFinanceManager.Persistence.Models.Core;

namespace CarFinanceManager.Persistence.Repositories.Interfaces
{
    public interface IExpensesRepository
    {
        void Add(ExpenseDetails expense);
        void AddCategory(ExpenseCategory category);
        IEnumerable<ExpenseDto> GetByUserName(string userName);
        ExpenseCategory GetCategoryByName(string categoryName);
    }
}