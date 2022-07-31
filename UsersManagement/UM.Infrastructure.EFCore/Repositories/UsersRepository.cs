using _01_Framework.Application;
using _01_Framework.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using UM.Application.Contracts.ViewModels;
using UM.Domain;
using UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace UM.Infrastructure.EFCore.Repositories
{
    public class UsersRepository : BaseRepository<long, User>, IUsersRepository
    {
        private readonly UMContext _UMcontext;
        public UsersRepository(UMContext UMcontext) : base(UMcontext)
        {
            _UMcontext = UMcontext;
        }

        public void Save()
        {
            _UMcontext.SaveChanges();
        }

        public UsersViewModel GetDetails(long id)
        {
            return _UMcontext.Tbl_Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Roles)
                .Where(x => x.Status == true)
                .Select(x => new UsersViewModel
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    IMGFileAddress = x.IMG,
                    Sex = x.Sex,
                    Tel = x.Tel,
                    Fullname = x.Sex.ToSexName() + " " + x.FirstName + " " + x.LastName,
                    UserStatus = x.Status,
                    UserRolesList = MapUserToRoles(x.UserRoles, x.ID)
                }).FirstOrDefault(x => x.ID == id);
        }
        public Dictionary<long, List<UsersViewModel>> Search(UsersViewModel command = null)
        {

            var UserInfo = _UMcontext
                .Tbl_Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Roles)
                .Where(x => x.Status == true)
                .Select(x => new UsersViewModel
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    IMGFileAddress = x.IMG,
                    Sex = x.Sex,
                    Tel = x.Tel,
                    Fullname = x.Sex.ToSexName() + " " + x.FirstName + " " + x.LastName,
                    UserStatus = x.Status,
                    UserRolesList = MapUserToRoles(x.UserRoles, x.ID)
                }).AsEnumerable().GroupBy(x => x.ID).ToList();

            //{
            //    if (!string.IsNullOrWhiteSpace(command.Fullname))
            //        UserInfo = UserInfo.Where(x => x.Fullname.Contains(command.Fullname));
            //}

            return UserInfo.ToDictionary(k => k.Key, v => v.ToList());

        }

        private static List<UsersRolesViewModel> MapUserToRoles(List<UserRole> userRoles, long uId)
        {
            return userRoles.Where(x => x.UserID == uId)
                .Where(x=>x.Status==true)
                .Select(x => new UsersRolesViewModel
            {
                ID = x.ID,
                RoleID = x.RoleID,
                RoleName = x.Roles.RoleName
            }).ToList();
        }

        public User GetByUsername(string username)
        {
            return _UMcontext.Tbl_Users
                           .Include(x => x.UserRoles)
                           .ThenInclude(x => x.Roles)
                           .Where(x => x.Status == true)
                           .FirstOrDefault(x => x.Email == username);
        }
    }
}
