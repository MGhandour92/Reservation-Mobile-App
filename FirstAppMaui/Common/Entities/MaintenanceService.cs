using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Common.Entities
{
	public class MaintenanceService
	{
        public int Id { get; set; }
        [Required]
        public string? ServiceName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }

		public ICollection<ReservationService>? Reservations { get; set; }
	}
}