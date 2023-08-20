using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
	public class ReservationService
	{
        public int Id { get; set; }

		public int MaintenanceServiceId { get; set; }
		public MaintenanceService? Service { get; set; }

		public int ReservationId { get; set; }
		public Reservation? Reservation { get; set; }
	}
}
