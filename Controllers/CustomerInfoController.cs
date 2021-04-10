using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicyleStoreAPI.Models;

namespace BicyleStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly BicycleStoreContext _bicyleStoreContext;
        public CustomerInfoController(BicycleStoreContext bicycleStoreContext)
        {
            _bicyleStoreContext = bicycleStoreContext;
        }

        /// <summary>
        /// Get all Customer Info
        /// </summary>
        /// <returns>customers</returns>
        [Route("/GetAllCustomers")]
        [HttpGet]
        public ActionResult<List<CustomerInfo>> GetAllCustomers()
        {
            var customers = _bicyleStoreContext.CustomerInfos.ToList();
            return customers;
        }

    }
}
