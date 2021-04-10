using BicyleStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicyleStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        private readonly BicycleStoreContext _bicyleStoreContext;

        private List<Bicycle> bicycleList = new List<Bicycle>();
        /// <summary>
        /// Constructor to inject dependency on BicycleStoreContext
        /// </summary>
        /// <param name="bicycleStoreContext"></param>
        public BicycleController(BicycleStoreContext bicycleStoreContext)
        {
            _bicyleStoreContext = bicycleStoreContext;
        }

        /// <summary>
        /// Get all bicycles 
        /// </summary>
        /// <returns>bicycle</returns>
        [Route("/GetAll")]
        [HttpGet]
        public ActionResult<List<Bicycle>> GetAll()
        {
            var bicycle = _bicyleStoreContext.Bicycles.ToList();
            return bicycle;

        }

        /// <summary>
        /// Gets bicylce(s) retrieved by BrandId and return ProductModel and ProductionYear
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns>bicycleList</returns>
        [Route("/GetBicycleByBrandId")]
        [HttpGet]
        public ActionResult<List<Bicycle>> GetBicycleByBrandId(int brandId)
        {
             
            var query = _bicyleStoreContext.Bicycles.Where(u => u.BrandId == brandId)
                .Select(c => new 
                {
                     c.ProductModel,
                     c.ProductionYear
                }).ToList();

            //adds the bicycles found in the lists to the bicycleList initialized in the beginning of this class
            foreach (var q in query)
            {
                Bicycle bbr = new Bicycle();
                bbr.ProductModel = q.ProductModel;
                bbr.ProductionYear = q.ProductionYear;
                bicycleList.Add(bbr);
            }
            return bicycleList;
        }

        /// <summary>
        /// Get a bicycle retrieved by ProductId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bicycle</returns>
        [Route("/GetById")]
        [HttpGet]
        public ActionResult<Bicycle> GetById(int id)
        {

            var bicycle = _bicyleStoreContext.Bicycles.FirstOrDefault(b => b.ProductId == id);
                       
             return bicycle;
            
        }
        /// <summary>
        /// Post/ Add a bicycle to Bicycle table
        /// </summary>
        /// <param name="bicycle"></param>
        [Route("/AddBicycle")]
        [HttpPost]
        public void AddBicycle(Bicycle bicycle)
        {
            //Create an object postedObj with Bicycle table attributes
            var postedObj = new Bicycle
                {
                    Price = bicycle.Price,
                    ProductionYear = bicycle.ProductionYear,
                    ProductModel = bicycle.ProductModel,
                    Gender = bicycle.Gender,
                    BrandId = bicycle.BrandId,
                    CategoryId = bicycle.CategoryId
                };
            // Add to the list
            _bicyleStoreContext.Bicycles.Add(postedObj);
            // Save the list
            _bicyleStoreContext.SaveChanges();
        }

        /// <summary>
        /// Edit/Modify retrieved by ProductId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bicycle"></param>
        /// <returns>bicycle</returns>
        [Route("/EditBicycle")]
        [HttpPut]
        public ActionResult<Bicycle> EditBicycle(int id, Bicycle bicycle)
        {
            if (id != bicycle.ProductId)
            {
                return BadRequest();
            }
            //Attaching the entity to DbContext and be ready to update 
            _bicyleStoreContext.Entry(bicycle).State = EntityState.Modified;
            _bicyleStoreContext.SaveChanges();
             return bicycle;
        }
        /// <summary>
        /// Delete/Remove the entity (bicycle) retrieved by ProductId
        /// </summary>
        /// <param name="bicycleId"></param>
        [Route("/DeleteBicycle")]
        [HttpPost]
        public void DeleteBicycle(int bicycleId)
        {

            // FirstOrDefault method returns first matching row from database. By Remove mothod the entity deleted.
            var toBeDeleted = _bicyleStoreContext.Bicycles.FirstOrDefault(b => b.ProductId == bicycleId);
            _bicyleStoreContext.Bicycles.Remove(toBeDeleted);

            _bicyleStoreContext.SaveChanges();



        }

    }
}
