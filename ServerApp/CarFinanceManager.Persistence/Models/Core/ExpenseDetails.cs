using System;
using CarFinanceManager.Persistence.Models.Accounts;

namespace CarFinanceManager.Persistence.Models.Core
{
    public class ExpenseDetails
    {
        public int ExpenseDetailsID { get; set; }
        public decimal Cost { get; set; }
        public DateTime DateCreated { get; set; }

        public ExpenseCategory Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}