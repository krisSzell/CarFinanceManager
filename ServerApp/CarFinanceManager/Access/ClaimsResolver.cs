using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using CarFinanceManager.Persistence.Models.Accounts;

namespace CarFinanceManager.Access
{
    public class ClaimsResolver : IClaimsResolver
    {
        public string GetUserNameFromRequestClaim(ClaimsIdentity claims)
        {
            return claims?.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
        }

        public ApplicationUser GetUserFromRequestClaim(ClaimsIdentity claims, IEnumerable<ApplicationUser> users)
        {
            var userName = GetUserNameFromRequestClaim(claims);
            return users.FirstOrDefault(u => u.UserName == userName);
        }
    }
}