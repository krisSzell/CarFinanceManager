using System.Collections.Generic;
using CarFinanceManager.Persistence.Models.Accounts;
using CarFinanceManager.Persistence.Models.Core;
using CarFinanceManager.Persistence.Repositories;
using CarFinanceManager.Persistence.Repositories.Interfaces;

namespace CarFinanceManager.Persistence
{
    public interface IUnitOfWork
    {
        IEnumerable<ApplicationUser> Users { get; set; }
        IExpensesRepository Expenses { get; set; }
        IVehiclesRepository Vehicles { get; set; }
    }
}