using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
	public class Car
	{
        public int Id { get; set; }
        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
		public int Year { get; set; }
		public int License { get; set; }

		public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

		public ICollection<Reservation>? Reservations { get; set; }
	}
}
