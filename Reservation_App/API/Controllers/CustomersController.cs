using Common.Entities;
using Common.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

		/// <summary>
		/// Endpoint return Customer Object by Id
		/// </summary>
		/// <param name="id">Customer Id</param>
		/// <returns>Customer Object</returns>
		[HttpGet("{id}")]
		public IActionResult GetCustomerById(int id)
		{
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

			var loginValid = ValidateCredentials(loginViewModel.Email!, loginViewModel.Password!);

			if (!loginValid)
			{
				return Unauthorized(new { Message = "Authentication failed" });
			}

			return Ok(new { Message = "Authentication Successful" });
		}


		//Helper Methods
		private bool ValidateCredentials(string userEmail, string password)
		{
			var customer =  _dBContext.Customers?.FirstOrDefault(user=> 
														user.Email!.ToUpper() == userEmail.ToUpper()
														&& user.Password!.ToUpper() == password.ToUpper());
			return customer is not null;
		}
	}
}
