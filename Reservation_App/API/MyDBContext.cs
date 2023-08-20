using Common;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API
{
	public class MyDBContext: DbContext
	{
        public DbSet<Customer>? Customers { get; set; }
		public DbSet<Car>? Cars { get; set; }
        public DbSet<MaintenanceService>? MaintenanceServices { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<ReservationService>? ReservationServices { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;");
		}
	}
}
