using _01_Framework.Domain;
using UM.Application.Contracts.ViewModels;
using UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace UM.Domain
{
    public interface IUsersRolesRepository : IRepository<long, UserRole>
    {
        UserRole GetByUserRole(long userID, long roleID);
        UsersRolesViewModel GetRolePermissionByUser(long userID);
        List<UserRole> GetRoleByUser(long userID);
    }
}
