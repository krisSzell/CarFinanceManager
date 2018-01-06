using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CarFinanceManager.Access;
using CarFinanceManager.Persistence;
using CarFinanceManager.Persistence.Dtos.Core;
using CarFinanceManager.Persistence.Models.Core;

namespace CarFinanceManager.Controllers.api
{
    [Authorize]
    [RoutePrefix("api/vehicles")]
    public class VehiclesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsResolver _claims;

        public VehiclesController(IUnitOfWork unitOfWork, IClaimsResolver claims)
        {
            _unitOfWork = unitOfWork;
            _claims = claims;
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetVehicles()
        {
            var userName = _claims
                .GetUserNameFromRequestClaim(User.Identity as ClaimsIdentity);

            var currentUserVehicles = _unitOfWork.Vehicles
                .GetAllByUsername(userName);

            return Ok(currentUserVehicles);
        }

        [Route("new")]
        [HttpPost]
        public IHttpActionResult AddVehicle([FromBody] VehicleDto vehicle)
        {
            var user = _claims.GetUserFromRequestClaim(User.Identity as ClaimsIdentity, _unitOfWork.Users);

            var domainVehicle = Mapper.Map<VehicleDto, Vehicle>(vehicle);
            domainVehicle.User = user;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.Vehicles.Add(domainVehicle);

            vehicle.Id = domainVehicle.VehicleId;
            vehicle.Username = user.UserName;

            return Ok(vehicle);
        }
    }
}