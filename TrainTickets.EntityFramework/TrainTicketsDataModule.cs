using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using TrainTickets.EntityFramework;

namespace TrainTickets
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(TrainTicketsCoreModule))]
    public class TrainTicketsDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TrainTicketsDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
