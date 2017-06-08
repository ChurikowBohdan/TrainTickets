using System.Data.Common;
using Abp.Zero.EntityFramework;
using TrainTickets.Authorization.Roles;
using TrainTickets.MultiTenancy;
using TrainTickets.Users;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TrainTickets.EntityFramework {
	public class TrainTicketsDbContext : AbpZeroDbContext<Tenant, Role, User> {
		//TODO: Define an IDbSet for your Entities...
		public IDbSet<Station> Stations { get; set; }
		public IDbSet<TrainType> TrainTypes { get; set; }
		public IDbSet<Train> Trains { get; set; }
		public IDbSet<Order> Orders { get; set; }
		public IDbSet<Route> Routes { get; set; }


		/* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
		public TrainTicketsDbContext()
			: base("Default") {

		}

		/* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TrainTicketsDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TrainTicketsDbContext since ABP automatically handles it.
         */
		public TrainTicketsDbContext(string nameOrConnectionString)
			: base(nameOrConnectionString) {

		}

		//This constructor is used in tests
		public TrainTicketsDbContext(DbConnection existingConnection)
		 : base(existingConnection, false) {

		}

		public TrainTicketsDbContext(DbConnection existingConnection, bool contextOwnsConnection)
		 : base(existingConnection, contextOwnsConnection) {

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Station>().ToTable("Station");
			modelBuilder.Entity<TrainType>().ToTable("TrainType");
			modelBuilder.Entity<Train>().ToTable("Train");
			modelBuilder.Entity<Order>().ToTable("Order");
			modelBuilder.Entity<Route>().ToTable("Route");

			modelBuilder.Entity<Train>().HasRequired(t => t.TrainType).WithMany().HasForeignKey(t => t.TrainTypeId);
			modelBuilder.Entity<Route>().HasRequired(t => t.ArrivalStation).WithMany().HasForeignKey(t => t.ArrivalStationId);
			modelBuilder.Entity<Route>().HasRequired(t => t.DisaptchingStation).WithMany().HasForeignKey(t => t.DispatchingStationId);
			modelBuilder.Entity<Route>().HasOptional(t => t.PreviousRoute).WithMany().HasForeignKey(t => t.PreviousRouteId);
			modelBuilder.Entity<Route>().HasRequired(t => t.Train).WithMany().HasForeignKey(t => t.TrainId);

			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		}
	}
}
