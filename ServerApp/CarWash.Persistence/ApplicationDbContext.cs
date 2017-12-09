using CarWash.Persistence.Models;
using CarWash.Persistence.Models.Accounts;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using CarWash.Persistence.Models.Core;
using CarWash.Persistence.Models.Core.Notifications;

namespace CarWash.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CarFinanceContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseDetails> Expenses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
