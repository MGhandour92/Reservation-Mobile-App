using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
	public class CustomerViewModel
	{
		public int CustomerId { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Email Not Valid")]
		public string? Email { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(10)]
		[DataType(DataType.Password)]
		public string? Password { get; set; }

		[Required]
		public string? FirstName { get; set; }
		[Required]
		public string? LastName { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		public string? Phone { get; set; }
	}
}
