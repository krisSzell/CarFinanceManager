using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    [RoutePrefix("api/expenses")]
    public class ExpenseController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsResolver _claims;

        public ExpenseController(IUnitOfWork unitOfWork, IClaimsResolver claims)
        {
            _unitOfWork = unitOfWork;
            _claims = claims;
        }

        [Route("current")]
        [HttpGet]
        public IHttpActionResult GetExpensesForCurrentUser()
        {
            var userName = _claims
                .GetUserNameFromRequestClaim(User.Identity as ClaimsIdentity);

            var currentUserExpenses = _unitOfWork.Expenses.GetByUserName(userName);

            return Ok(currentUserExpenses);
        }

        [Route("new")]
        [HttpPost]
        public IHttpActionResult AddExpense([FromBody] ExpenseDto expense)
        {
            var user = _claims.GetUserFromRequestClaim(User.Identity as ClaimsIdentity, _unitOfWork.Users);

            var category = _unitOfWork.Expenses.GetCategoryByName(expense.Category);
            if (category == null)
                return BadRequest("Category doesn't exist");

            var vehicle = _unitOfWork.Vehicles.GetSingleById(expense.VehicleId);

            var domainExpense = Mapper.Map<ExpenseDto, ExpenseDetails>(expense);
            domainExpense.Category = category;
            domainExpense.User = user;
            domainExpense.Vehicle = vehicle;

            if (!ModelState.IsValid)
                return BadRequest("Model is invalid");

            _unitOfWork.Expenses.Add(domainExpense);

            expense.Id = domainExpense.ExpenseDetailsID;

            return Ok(expense);
        }
    }
}