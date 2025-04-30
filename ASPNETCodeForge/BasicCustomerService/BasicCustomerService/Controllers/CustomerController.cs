using BasicCustomerService.Data;
using BasicCustomerService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicCustomerService.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public CustomerController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {

            if (_context.Customers == null)
            {
                return NotFound("No customers found.");
            }

            //var customers = await _context.Customers.ToListAsync();
            var customers = await _context.Customers
                .Include(c  => c.Addresses)
                .ToListAsync();

            return Ok(customers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound("No customers found.");
            }

            //var customer = await _context.Customers.FindAsync(id);
            var customer = await _context.Customers
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest("Customer ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound($"Customer with ID {id} not found.");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound("No customers found.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
