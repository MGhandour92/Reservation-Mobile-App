using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
	public class Car
	{
        public int Id { get; set; }
		public string? Make { get; set; }
		public string? Model { get; set; }
		public int Year { get; set; }
		public int License { get; set; }

		public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

		public ICollection<Reservation>? Reservations { get; set; }
	}
}
