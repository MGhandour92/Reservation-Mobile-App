using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
	public class Reservation
	{
        public int Id { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }


        [Required]
        public int CustomerId { get; set; }
		public Customer? Customer { get; set; }
        [Required]
        public int CarId { get; set; }
		public Car? Car { get; set; }

		public ICollection<ReservationService>? Services { get; set; }
	}
}
