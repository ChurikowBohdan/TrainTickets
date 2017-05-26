using System.Data.Common;
using Abp.Zero.EntityFramework;
using TrainTickets.Authorization.Roles;
using TrainTickets.MultiTenancy;
using TrainTickets.Users;
using TrainTickets.Customers;
using System.Data.Entity;
using TrainTickets.Routes;
using TrainTickets.Tickets;
using TrainTickets.Trains;
using TrainTickets.AdministrationArea;

namespace TrainTickets.EntityFramework
{
    public class TrainTicketsDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Administration> Administrations { get; set; }
        public IDbSet<IntermediateStation> IntermediateStations { get; set; }
        public IDbSet<Route> Routes { get; set; }
        public IDbSet<Ticket>Tickets { get; set; }
        public IDbSet<Schedule> Schedules { get; set; }
        public IDbSet<Train> Trains { get; set; }
        
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public TrainTicketsDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TrainTicketsDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TrainTicketsDbContext since ABP automatically handles it.
         */
        public TrainTicketsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public TrainTicketsDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public TrainTicketsDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Administration>().ToTable("Administration");
            modelBuilder.Entity<IntermediateStation>().ToTable("IntermediateStation");
            modelBuilder.Entity<Route>().ToTable("Route");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<Schedule>().ToTable("Schedule");
            modelBuilder.Entity<Train>().ToTable("Train");
            

        }
    }
}
