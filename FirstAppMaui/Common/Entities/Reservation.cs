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
        public DateTime ReservationDate { get; set; } = DateTime.Today.AddDays(1);


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please a Customer")]
        public int CustomerId { get; set; }
		public Customer? Customer { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please a Car")]
        public int CarId { get; set; }
		public Car? Car { get; set; }

		public ICollection<ReservationService>? Services { get; set; }
	}
}
