using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace CarFinanceManager.Access
{
    public class ClaimsResolver
    {
        public string GetUserNameFromRequestClaim(ClaimsIdentity claims)
        {
            return claims?.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
        }
    }
}