using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using CarFinanceManager.Persistence.Dtos.Core;
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

        public IEnumerable<ExpenseDto> GetByUserName(string userName)
        {
            return _context.Expenses
                .Where(e => e.User.UserName == userName)
                .Include(e => e.Category)
                .Select(e => new ExpenseDto
                    {
                        Id = e.ExpenseDetailsID,
                        Category = e.Category.Name,
                        Cost = e.Cost,
                        DateCreated = e.DateCreated
                    })
                .ToList();
        }

        public ExpenseCategory GetCategoryByName(string categoryName)
        {
            return _context.ExpenseCategories
                .SingleOrDefault(c => c.Name == categoryName);
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