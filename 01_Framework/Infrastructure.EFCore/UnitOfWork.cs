using _01_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_Framework.Infrastructure.EFCore
{
    public class UnitOfWork : IUnitOfWork //where T:DbContext
    {
        private readonly DbContext _dbcontext;
        public UnitOfWork(DbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void BeginTran()
        {
            _dbcontext.Database.BeginTransaction();
        }
        public void CommitTran()
        {
            _dbcontext.SaveChanges();
            _dbcontext.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _dbcontext.Database.RollbackTransaction();
        }
    }
}
