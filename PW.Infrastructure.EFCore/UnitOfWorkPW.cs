using _01_Framework.Infrastructure.EFCore;
using PW.Domain;
using PW.Infrastructure.EFCore;

namespace UM.Infrastructure.EFCore.Repositories
{
    public class UnitOfWorkPW : UnitOfWork, IUnitOfWorkPW
    {
        private readonly EMContext _EMcontext;
        public UnitOfWorkPW(EMContext EMcontext) : base(EMcontext)
        {
            _EMcontext = EMcontext;
        }
    }
}
