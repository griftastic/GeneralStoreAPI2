using GeneralStoreAPI2.Controllers;
using GeneralStoreAPI2.Data;
using GeneralStoreAPI2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI2.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ProductController : Controller
    {
        private readonly GeneralStoreDBContext _db;
        private readonly ILogger<ProductController> _logger;
        public ProductController(GeneralStoreDBContext db, ILogger<ProductController> logger) {
            _db = db;
            _logger = logger;
        }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm]ProductEdit newProduct) {
        Product product = new Product() {
            Name = newProduct.Name,
            Price = newProduct.Price,
            QuantityInStock = newProduct.Quantity,
        };
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts() {
        var products = await _db.Products.ToListAsync();
        return Ok(products);
    }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}