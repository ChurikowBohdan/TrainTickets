using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace TrainTickets.EntityFramework.Repositories
{
    public abstract class TrainTicketsRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TrainTicketsDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected TrainTicketsRepositoryBase(IDbContextProvider<TrainTicketsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class TrainTicketsRepositoryBase<TEntity> : TrainTicketsRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected TrainTicketsRepositoryBase(IDbContextProvider<TrainTicketsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
