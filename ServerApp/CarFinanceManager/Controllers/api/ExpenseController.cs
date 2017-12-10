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
using CarFinanceManager.Access;
using CarFinanceManager.Persistence;
using CarFinanceManager.Persistence.Models.Core;

namespace CarFinanceManager.Controllers.api
{
    public class ExpenseController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetExpensesForCurrentUser()
        {
            var userName = new ClaimsResolver()
                .GetUserNameFromRequestClaim(User.Identity as ClaimsIdentity);

            var currentUserExpenses = _unitOfWork.Expenses.GetByUserName(userName);

            return Ok(currentUserExpenses);
        }
    }
}