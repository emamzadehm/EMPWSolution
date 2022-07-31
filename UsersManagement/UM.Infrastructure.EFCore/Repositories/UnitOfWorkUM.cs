using _01_Framework.Infrastructure.EFCore;
using UM.Domain;

namespace UM.Infrastructure.EFCore.Repositories
{
    public class UnitOfWorkUM : UnitOfWork, IUnitOfWorkUM
    {
        private readonly UMContext _UMcontext;
        public UnitOfWorkUM(UMContext UMcontext) : base(UMcontext)
        {
            _UMcontext = UMcontext;
        }
    }
}
