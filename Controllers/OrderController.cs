using BicyleStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BicyleStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BicycleStoreContext _bicyleStoreContext;
        private List<Order> orderList = new List<Order>();
        public OrderController(BicycleStoreContext bicycleStoreContext)
        {
            _bicyleStoreContext = bicycleStoreContext;
        }
        /// <summary>
        /// Get customer & order quantity retrieved by OrderId. Returns CustomerId & Quantity 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>orderList</returns>
        [Route("/GetCustomerinfoByOrderId")]
        [HttpGet]
        public ActionResult<List<Order>> GetCustomerinfoByOrderId(int orderId)
        {

            var lists = _bicyleStoreContext.Orders.Where(o => o.OrderId == orderId)
                .Select(q => new 
                {
                    q.CustomerId,
                    q.Quantity 
                }).ToList();
            //adds the customers found in the lists to the order initialized in the beginning of this class
            foreach (var item in lists)
            {
                Order or = new Order();
                or.CustomerId = item.CustomerId;
                or.Quantity = item.Quantity;
                orderList.Add(or);

            }
            return orderList;
        }


    }
}
