using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
	public class LoginViewModel
	{
		[Required]
		[EmailAddress(ErrorMessage = "Email Not Valid")]
		public string? Email { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(10)]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
	}
}
