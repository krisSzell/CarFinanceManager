using System.Collections.Generic;
using System.Linq;
using CarFinanceManager.Persistence.Models.Accounts;
using CarFinanceManager.Persistence.Models.Core;
using CarFinanceManager.Persistence.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarFinanceManager.Persistence.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ExpensesRepository(ApplicationDbContext context)
        {
            _context = context;
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }

        public IEnumerable<ExpenseDetails> GetByUserName(string userName)
        {
            return _context.Expenses.Where(e => e.User.UserName == userName).ToList();
        }

        public void Add(ExpenseDetails expense)
        {
            _context.Expenses.Add(expense);
        }

        public void AddCategory(ExpenseCategory category)
        {
            _context.ExpenseCategories.Add(category);
        }
    }
}