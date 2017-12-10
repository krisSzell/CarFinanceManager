using System.Threading.Tasks;
using CarFinanceManager.Persistence.Models.Accounts;
using Microsoft.AspNet.Identity;

namespace CarFinanceManager.Persistence.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(RegisterModel registerModel);
        ApplicationUser FindUserByUsername(string username);
    }
}
