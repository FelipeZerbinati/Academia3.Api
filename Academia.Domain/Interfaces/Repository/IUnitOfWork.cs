using Academia2.Domain.Interfaces.Postgres;
using acdm = Academia2.Domain.Models;

namespace Academia2.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IRepositoryBase<acdm.Academia2> Academia2Repository { get; }
        Task<bool> CommitAsync();
    }
}
