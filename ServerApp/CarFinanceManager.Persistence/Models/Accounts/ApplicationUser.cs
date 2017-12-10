using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CarFinanceManager.Persistence.Models.Core;
using CarFinanceManager.Persistence.Models.Core.Notifications;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarFinanceManager.Persistence.Models.Accounts
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surename { get; set; }
        public ICollection<Vehicle> VehiclesOwned { get; set; }
        public ICollection<ExpenseDetails> Expenses { get; set; }
        public ICollection<UserNotification> UserNotifications { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
