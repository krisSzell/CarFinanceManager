using System.Collections.Generic;
using System.Linq;
using CarFinanceManager.Persistence.Models.Accounts;
using CarFinanceManager.Persistence.Repositories;
using CarFinanceManager.Persistence.Repositories.Interfaces;

namespace CarFinanceManager.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = _context.Users.ToList();
            Expenses = new ExpensesRepository(_context);
            Vehicles = new VehiclesRepository(_context);
        }

        public IEnumerable<ApplicationUser> Users { get; set; }
        public IExpensesRepository Expenses { get; set; }
        public IVehiclesRepository Vehicles { get; set; }
    }
}