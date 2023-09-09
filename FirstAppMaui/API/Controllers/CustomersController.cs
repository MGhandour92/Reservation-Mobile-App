using Common.Entities;
using Common.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly MyDBContext _dBContext;

		public CustomersController(MyDBContext dBContext)
		{
			_dBContext = dBContext;
		}

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_dBContext.Customers == null)
            {
                return NotFound();
            }
            return await _dBContext.Customers.ToListAsync();
        }

        /// <summary>
        /// Endpoint return Customer Object by Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Customer Object</returns>
        [HttpGet("{id}")]
		public IActionResult GetCustomerById(int id)
		{
            if (_dBContext.Customers == null)
                return NotFound();

            var returnedCustomer = _dBContext.Customers?.Find(id);

			if (returnedCustomer == null)
				return NotFound();

			var customerVM = new CustomerViewModel()
			{
				CustomerId = id,
				Password = returnedCustomer.Password,
				FirstName = returnedCustomer.FirstName,
				LastName = returnedCustomer.LastName,
				Email = returnedCustomer.Email,
				Phone = returnedCustomer.Phone
			};

			return Ok(customerVM);
		}


		/// <summary>
		/// Endpoint Create New Customer
		/// </summary>
		/// <param name="customerVM">Customer Object</param>
		/// <returns></returns>
		[HttpPost]
		[Route("register")]
		public IActionResult Registeration([FromBody] CustomerViewModel customerVM)
		{
            if (_dBContext.Customers == null)
            {
                return Problem("Entity set 'MyDBContext.Customers'  is null.");
            }
            
			if (!ModelState.IsValid)
				return BadRequest("Input Data is not valid");

			var customerEntity = new Customer
			{
				Email = customerVM.Email,
				Password = customerVM.Password,
				FirstName = customerVM.FirstName,
				LastName = customerVM.LastName,
				Phone = customerVM.Phone
			};

			_dBContext.Customers?.Add(customerEntity);
			_dBContext.SaveChanges();

			customerVM.CustomerId = customerEntity.Id;

			return CreatedAtAction(nameof(GetCustomerById), new { id = customerVM.CustomerId }, customerVM);
		}

		/// <summary>
		/// Login by Email and password
		/// </summary>
		/// <param name="loginViewModel">Login VM</param>
		/// <returns>Customer Object</returns>
		[HttpPost]
		[Route("login")]
		public IActionResult Login([FromBody] LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var validCustomer = ValidateCredentials(loginViewModel.Email, loginViewModel.Password);

			if (validCustomer is null)
			{
				return Unauthorized(new { Message = "Authentication failed" });
			}

			return Ok(validCustomer.Id);
		}


        // PUT: api/Customers1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _dBContext.Entry(customer).State = EntityState.Modified;

            try
            {
                await _dBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Customers1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_dBContext.Customers == null)
            {
                return NotFound();
            }
            var customer = await _dBContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _dBContext.Customers.Remove(customer);
            await _dBContext.SaveChangesAsync();

            return NoContent();
        }

        //Helper Methods
        private Customer? ValidateCredentials(string userEmail, string password)
		{
			var customer =  _dBContext.Customers?.FirstOrDefault(user=> 
														user.Email!.ToUpper() == userEmail.ToUpper()
														&& user.Password!.ToUpper() == password.ToUpper());
			return customer;
		}

        private bool CustomerExists(int id)
        {
            return (_dBContext.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
