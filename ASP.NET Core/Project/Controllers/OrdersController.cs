using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpGet]
        public List<Order> GetOrders()
        {
            List<Order> result = new List<Order>();
            using (var db = new p02_efarmingContext())
            {
                result = db.Orders.ToList();
            }
            return result;
        }


        [HttpGet]
        public List<Order> GetOrdersWithOrderDetails()
        {
            List<Order> result = new List<Order>();
            using (var db = new p02_efarmingContext())
            {
                result = db.Orders.Include(add => add.Orderdetails).ToList();
            }
            return result;
        }

        [HttpPost]
        public Order SaveOrder(Order order)
        {
            using (var db = new p02_efarmingContext())
            {
                // Calculate total price from OrderDetails
                order.TotalPrice = order.Orderdetails.Sum(od => od.Qty * od.Price);

                db.Orders.Add(order);
                db.SaveChanges();
            }
            return order;
        }






    }
}