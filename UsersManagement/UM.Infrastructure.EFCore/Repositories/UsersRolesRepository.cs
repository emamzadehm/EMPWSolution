using _01_Framework.Application;
using _01_Framework.Infrastructure.EFCore;
using UM.Application.Contracts.ViewModels;
using UM.Domain;
using UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace UM.Infrastructure.EFCore.Repositories
{
    public class UsersRolesRepository : BaseRepository<long, UserRole>, IUsersRolesRepository
    {
        private readonly UMContext _UMcontext;
        public UsersRolesRepository(UMContext UMcontext) : base(UMcontext)
        {
            _UMcontext = UMcontext;
        }

        public UserRole GetByUserRole(long userID, long roleID)
        {
            return _UMcontext.Tbl_Users_Roles
                .Where(x => x.Status == true)
                .FirstOrDefault(x => x.UserID == userID && x.RoleID == roleID);
        }

        public List<UserRole> GetRoleByUser(long userID)
        {
            return _UMcontext.Tbl_Users_Roles
                            .Where(x => x.Status == true && x.UserID == userID).ToList();
        }

        public UsersRolesViewModel GetRolePermissionByUser(long userID)
        {
            var result = _UMcontext.Tbl_Users
                .Where(x => x.Status == true)
                .Select(x => new UsersRolesViewModel
                {
                    UserID = x.ID,
                    Username = x.Email,
                    Fullname = x.Sex.ToSexName() + " " + x.FirstName + " " + x.LastName,
                    Status = x.Status,
                }).FirstOrDefault(x => x.UserID == userID);

            result.RolesList = _UMcontext.Tbl_Users_Roles.Where(x => x.UserID == result.UserID && x.Status==true && x.Roles.Status==true)
                .Select(x => new UsersRolesViewModel
                {
                    ID = x.ID,
                    RoleID = x.RoleID,
                    RoleName = x.Roles.RoleName
                }).ToList();
            return result;
        }

    }
}
