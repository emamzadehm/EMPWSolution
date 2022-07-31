using _01_Framework.Domain;
using UM.Application.Contracts.ViewModels;
using UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace UM.Domain
{
    public interface IRolesRepository : IRepository<long, Role>
    {
        List<RolesViewModel> Search(RolesViewModel command = null);
        RolesViewModel GetDetails(long id);
    }
}
