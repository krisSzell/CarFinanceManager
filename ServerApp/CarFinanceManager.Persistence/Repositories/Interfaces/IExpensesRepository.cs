using System.Collections.Generic;
using CarFinanceManager.Persistence.Models.Core;

namespace CarFinanceManager.Persistence.Repositories.Interfaces
{
    public interface IExpensesRepository
    {
        void Add(ExpenseDetails expense);
        void AddCategory(ExpenseCategory category);
        IEnumerable<ExpenseDetails> GetByUserName(string userName);
    }
}