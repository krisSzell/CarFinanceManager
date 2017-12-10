using System.Collections.Generic;
using CarFinanceManager.Persistence.Models.Accounts;

namespace CarFinanceManager.Persistence
{
    public interface IUnitOfWork
    {
        IEnumerable<ApplicationUser> Users { get; set; }
        void PersistChanges();
    }
}