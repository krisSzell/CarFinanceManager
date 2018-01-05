using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using CarFinanceManager.Persistence.Models.Accounts;
using CarFinanceManager.Persistence.Repositories.Interfaces;
using Microsoft.AspNet.Identity;

namespace CarFinanceManager.Controllers.api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        private readonly IAuthRepository _authRepo;

        public AccountController(IAuthRepository repository)
        {
            _authRepo = repository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authRepo.RegisterUser(registerModel);
            var errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }


        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
