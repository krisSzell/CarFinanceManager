using System.Collections.Generic;
using System.Linq;
using CarFinanceManager.Persistence.Models.Accounts;
using CarFinanceManager.Persistence.Repositories;
using CarFinanceManager.Persistence.Repositories.Interfaces;

namespace CarFinanceManager.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Users = new ApplicationDbContext().Users.ToList();
            Expenses = new ExpensesRepository(new ApplicationDbContext());
            Vehicles = new VehiclesRepository(new ApplicationDbContext());
        }

        public IEnumerable<ApplicationUser> Users { get; set; }
        public IExpensesRepository Expenses { get; set; }
        public IVehiclesRepository Vehicles { get; set; }
    }
}