using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayemntController : ControllerBase
    {
        [HttpGet]
        public List<PaymentMode> GetModes()
        {
            List<PaymentMode> modes = new List<PaymentMode>();
            using (var db = new p02_efarmingContext())
            {
                modes = db.PaymentModes.ToList();
            }
            return modes;
        }


        [HttpPost]
        public PaymentMode SaveMode(PaymentMode mode)
        {
            using (var db = new p02_efarmingContext())
            {
                db.PaymentModes.Add(mode);
                db.SaveChanges();
            }
            return mode;
        }
    }
}
