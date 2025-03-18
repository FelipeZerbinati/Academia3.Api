using Academia2.Data.Postgres.Context;
using acdm = Academia2.Domain.Models;
using Academia2.Domain.Interfaces.Postgres;
using Academia.Data.Postgres.Repository;
using Academia2.Domain.Interfaces.Repository;

namespace Academia2.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        //contexts
        private readonly PostgresDbContext _postgresContext;
        //repositorys
        private IRepositoryBase<acdm.Academia2>? _academiaRepository;

        public UnitOfWork(
PostgresDbContext postgresContext)
        {
            //constructor
            _postgresContext = postgresContext;
            //repositoryInject

        }

        //injections
        public IRepositoryBase<acdm.Academia2> Academia2Repository => _academiaRepository ?? (_academiaRepository = new RepositoryBase<acdm.Academia2>(_postgresContext));


        public async Task<bool> CommitAsync()
        {
            return await _postgresContext.SaveChangesAsync() > 0;
        }
    }
}
