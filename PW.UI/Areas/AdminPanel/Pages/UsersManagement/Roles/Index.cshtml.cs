using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UM.Application.Contracts.Interfaces;
using UM.Application.Contracts.ViewModels;

namespace Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagemeRoles
{
    public class IndexModel : PageModel
    {
        public IRolesApplication _irolesApplication;
        public List<RolesViewModel> roleVM { get; set; }
        public RolesViewModel SearchModel { get; set; }

        public IndexModel(IRolesApplication irolesApplication)
        {
            _irolesApplication = irolesApplication;
        }

        public void OnGet(RolesViewModel searchmodel)
        {
            roleVM = _irolesApplication.Search(searchmodel);
        }
        public IActionResult OnGetRemove(RolesViewModel rolevm)
        {
            _irolesApplication.Remove(rolevm.ID);
            return RedirectToPage("Index");
        }
    }
}
