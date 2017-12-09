using System.Collections.Generic;
using System.Linq;
using CarWash.Persistence.Models.Accounts;

namespace CarWash.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = _context.Users.ToList();
        }

        public IEnumerable<ApplicationUser> Users { get; set; }

        public void PersistChanges()
        {
            _context.SaveChanges();
        }
    }
}