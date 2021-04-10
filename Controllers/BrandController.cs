using BicyleStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicyleStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly BicycleStoreContext _bicyleStoreContext;
        public BrandController(BicycleStoreContext bicycleStoreContext)
        {
            _bicyleStoreContext = bicycleStoreContext;
        }

        /// <summary>
        /// Get all brands
        /// </summary>
        /// <returns>all</returns>
        [Route("/GetAllBrands")]
        [HttpGet]
        public ActionResult<List<Brand>> GetAllBrands()
        {
            var all = _bicyleStoreContext.Brands.ToList();
            return all;
        }
    }
}
