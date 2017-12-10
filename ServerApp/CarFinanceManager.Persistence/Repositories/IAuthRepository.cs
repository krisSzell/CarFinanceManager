using System.Threading.Tasks;
using CarFinanceManager.Persistence.Models.Accounts;
using Microsoft.AspNet.Identity;

namespace CarFinanceManager.Persistence.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(RegisterModel registerModel);
        ApplicationUser FindUserByUsername(string username);
    }
}
