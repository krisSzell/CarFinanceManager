using System.Collections.Generic;
using System.Linq;
using CarFinanceManager.Persistence.Models.Accounts;
using CarFinanceManager.Persistence.Models.Core;
using CarFinanceManager.Persistence.Repositories;

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
        }

        public IEnumerable<ApplicationUser> Users { get; set; }
        public ExpensesRepository Expenses { get; set; }

        public void PersistChanges()
        {
            _context.SaveChanges();
        }
    }
}