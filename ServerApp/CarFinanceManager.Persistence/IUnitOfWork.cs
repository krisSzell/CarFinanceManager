using System.Collections.Generic;
using CarFinanceManager.Persistence.Models.Accounts;
using CarFinanceManager.Persistence.Models.Core;
using CarFinanceManager.Persistence.Repositories;

namespace CarFinanceManager.Persistence
{
    public interface IUnitOfWork
    {
        IEnumerable<ApplicationUser> Users { get; set; }
        ExpensesRepository Expenses { get; set; }
        void PersistChanges();
    }
}