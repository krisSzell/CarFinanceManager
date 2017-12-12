using System.Collections.Generic;
using System.Security.Claims;
using CarFinanceManager.Persistence.Models.Accounts;

namespace CarFinanceManager.Access
{
    public interface IClaimsResolver
    {
        string GetUserNameFromRequestClaim(ClaimsIdentity claims);
        ApplicationUser GetUserFromRequestClaim(ClaimsIdentity claims, IEnumerable<ApplicationUser> users);
    }
}