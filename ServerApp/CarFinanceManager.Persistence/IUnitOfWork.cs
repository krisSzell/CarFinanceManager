using System.Collections.Generic;
using CarWash.Persistence.Models.Accounts;

namespace CarWash.Persistence
{
    public interface IUnitOfWork
    {
        IEnumerable<ApplicationUser> Users { get; set; }
        void PersistChanges();
    }
}