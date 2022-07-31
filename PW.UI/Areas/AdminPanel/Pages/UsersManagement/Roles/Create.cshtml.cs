using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UM.Application.Contracts.Interfaces;
using UM.Application.Contracts.ViewModels;


namespace Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagemeRoles
{
    public class CreateModel : PageModel
    {
        public RolesViewModel RoleVM { get; set; }
        public IRolesApplication _irolesApplication;

        public CreateModel(IRolesApplication irolesApplication)
        {
            _irolesApplication = irolesApplication;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(RolesViewModel rolevm)
        {
            _irolesApplication.Create(rolevm);
            return RedirectToPage("Index");
        }

    }
}
