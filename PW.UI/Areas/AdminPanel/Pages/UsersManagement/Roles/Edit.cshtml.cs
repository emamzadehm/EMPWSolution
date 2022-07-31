using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UM.Application.Contracts.Interfaces;
using UM.Application.Contracts.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagemeRoles
{
    public class EditModel : PageModel
    {
        public RolesViewModel RoleVM { get; set; }
        public IRolesApplication _irolesApplication;

        public List<SelectListItem> Roles = new List<SelectListItem>();

        public EditModel(IRolesApplication irolesApplication)
        {
            _irolesApplication = irolesApplication;
        }

        public void OnGet(long id)
        {
            Roles = GetPermissionsByRole(id);
        }

        public List<SelectListItem> GetPermissionsByRole(long id)
        {
            RoleVM = _irolesApplication.GetDetails(id);
            return Roles;
        }


        public IActionResult OnPost(RolesViewModel rolevm)
        {
            _irolesApplication.Edit(rolevm);
            return RedirectToPage("Index");
        }
    }
}
