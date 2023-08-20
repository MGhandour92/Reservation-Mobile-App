using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
	public class Reservation
	{
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }


		public int CustomerId { get; set; }
		public Customer? Customer { get; set; }
		public int CarId { get; set; }
		public Car? Car { get; set; }

		public ICollection<ReservationService>? Services { get; set; }
	}
}
