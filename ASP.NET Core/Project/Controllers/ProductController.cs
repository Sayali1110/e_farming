using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerProductController : ControllerBase
    {
        private readonly p02_efarmingContext _context;

        public FarmerProductController(p02_efarmingContext context)
        {
            _context = context;
        }

        [HttpGet]

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products
                .Select(p => new { p.Pid, p.Pname }) // Ensure only necessary fields are selected
                .ToList();

            return Ok(products);
        }


        [HttpGet("GetProductTypes/{pid}")]
        public IActionResult GetProductTypes(int pid)
        {
            var productTypes = _context.Producttypes
                .Where(pt => pt.Pid == pid)
                .Select(pt => new { pt.Ptid, pt.Ptname }) // Selecting only necessary fields
                .ToList();

            if (productTypes.Count == 0)
                return NotFound(new { message = "No product types found for this product ID." });

            return Ok(productTypes);

        }
           
            [HttpPost("getById")]
        public async Task<ActionResult<object>> GetFarmerProductById([FromBody] int fptid)
        {
            var product = await _context.Farmerproducttypes
                .Where(f => f.Fptid == fptid)
                .Select(f => new
                {
                    f.Images,  // Assuming this stores the image filename
                    f.Price,
                    ProductName = f.Pt.Ptname, // Assuming Product Name is stored in ProductType
                    f.Ptid,
                    f.Fptid
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            return Ok(product);
        }
    }


}



