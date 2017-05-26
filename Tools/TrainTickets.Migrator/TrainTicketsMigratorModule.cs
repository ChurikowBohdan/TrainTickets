using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using TrainTickets.EntityFramework;

namespace TrainTickets.Migrator
{
    [DependsOn(typeof(TrainTicketsDataModule))]
    public class TrainTicketsMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TrainTicketsDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}