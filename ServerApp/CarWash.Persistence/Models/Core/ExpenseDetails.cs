using System;

namespace CarWash.Persistence.Models.Core
{
    public class ExpenseDetails
    {
        public int ExpenseDetailsID { get; set; }
        public decimal Cost { get; set; }
        public DateTime DateCreated { get; set; }

        public ExpenseCategory Category { get; set; }
    }
}