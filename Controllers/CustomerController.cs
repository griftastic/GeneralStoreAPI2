using GeneralStoreAPI2.Data;
using GeneralStoreAPI2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private GeneralStoreDBContext _db;
        public CustomerController(GeneralStoreDBContext db) {
            _db = db;
        }
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromForm] CustomerEdit newCustomer) {
        Customer customer = new Customer() {
            Name = newCustomer.Name,
            Email = newCustomer.Email,
        };
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers() {
        var customers = await _db.Customers.ToListAsync();
        return Ok(customers);
    }
    }
}