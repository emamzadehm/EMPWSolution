using _01_Framework.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using UM.Application.Contracts.ViewModels;
using UM.Domain;
using UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace UM.Infrastructure.EFCore.Repositories
{
    public class RolesRepository : BaseRepository<long, Role>, IRolesRepository
    {
        private readonly UMContext _UMcontext;
        public RolesRepository(UMContext UMcontext) : base(UMcontext)
        {
            _UMcontext = UMcontext;
        }

        public RolesViewModel GetDetails(long id)
        {
            var result = _UMcontext.Tbl_Roles.Where(x => x.Status == true).Select(x => new RolesViewModel
            {
                ID = x.ID,
                RoleName = x.RoleName,
                Description = x.Description,
                Status = x.Status
            }).FirstOrDefault(x => x.ID == id);


            return result;
        }


        public List<RolesViewModel> Search(RolesViewModel command = null)
        {
            var Query = _UMcontext.Tbl_Roles.Where(x => x.Status == true).Select(x => new RolesViewModel
            {
                ID = x.ID,
                RoleName = x.RoleName,
                Description = x.Description,
                Status = x.Status
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.RoleName))
                    Query = Query.Where(x => x.RoleName.Contains(command.RoleName));
            }
            return Query.ToList();
        }
    }
}
