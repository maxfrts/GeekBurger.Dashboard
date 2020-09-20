using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Service;
using GeekBurger.Dashboard.Service.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace GeekBurger.Dashboard.Controllers
{
    public class DashboardController : Controller
    {
        public readonly ISalesService _salesService;
        public readonly IUserRestrictionsService _userRestrictionsService;

        public DashboardController(ISalesService salesService, IUserRestrictionsService userRestrictionsService)
        {
            _salesService = salesService;
            _userRestrictionsService = userRestrictionsService;
        }

        /// <summary>
        /// Retrieves a list of UserRestrictionsService.
        /// </summary>
        [HttpGet]
        [Route("api/dashboard/usersWithLessOffer/")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetUsersWithLessOffer()
        {
            var usersRestrictions = _userRestrictionsService.ConsolidateUserRestrictions();

            return Ok(usersRestrictions.Result);
        }

        [HttpGet]
        [Route("api/dashboard/sales/")]
        [EnableCors("AllowOrigin")]
        public IActionResult Sales([FromQuery]SalesRequest salesRequest)
        {
            var sales = _salesService.GetSales(salesRequest);

            return Ok(sales.Result);
        }

    }
}
