using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UM.Application.Contracts.Interfaces;
using UM.Application.Contracts.ViewModels;

namespace Presentation.MVCCore.Areas.AdminPanel.Pages.UsersManagemeUsers
{
    public class IndexModel : PageModel
    {
        public IUserApplication _iuserapplication;
        public IRolesApplication _irolesapplication;

        public Dictionary<long, List<UsersViewModel>> userVM { get; set; }
        public UsersViewModel SearchModel { get; set; }

        public IndexModel(IUserApplication iuserapplication, IRolesApplication irolesapplication)
        {
            _iuserapplication = iuserapplication;
            _irolesapplication = irolesapplication;
        }

        public void OnGet(UsersViewModel searchmodel)
        {
            userVM = _iuserapplication.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new UsersViewModel());
        }
        public JsonResult OnPostCreate(UsersViewModel uservm)
        {
            var result = _iuserapplication.Create(uservm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var selecteditem = _iuserapplication.GetDetails(id);
            return Partial("./Edit", selecteditem);
        }

        public JsonResult OnPostEdit(UsersViewModel uservm)
        {
            var result = _iuserapplication.Edit(uservm);
            return new JsonResult(result);
        }

        public IActionResult OnGetShowRole(long id)
        {
            var selecteditem = _iuserapplication.GetDetails(id);
            selecteditem.RolesList = _irolesapplication.Search();
            return Partial("./ShowRole", selecteditem);
        }

        public IActionResult OnGetCreateRole(long roleId, long userId)
        {
            _iuserapplication.CreateRole(roleId,userId);
            return RedirectToPage("Index");
        }
        public IActionResult OnGetRemoveRole(long roleId, long userId)
        {
            _iuserapplication.RemoveRole(roleId, userId);
            return RedirectToPage("Index");
        }
        public IActionResult OnGetRemove(UsersViewModel uservm)
        {
            _iuserapplication.Remove(uservm.ID);
            return RedirectToPage("Index");
        }
        public IActionResult OnGetView(long id)
        {
            var selecteditem = _iuserapplication.GetDetails(id);
            return Partial("./View", selecteditem);
        }
        public IActionResult OnGetChangePassword(long id)
        {
            var selecteditem = _iuserapplication.GetDetails(id);
            return Partial("./ChangePassword", selecteditem);
        }
        public JsonResult OnPostChangePassword(UsersViewModel uservm)
        {
            var result = _iuserapplication.ChangePassword(uservm.ID,uservm.Password);
            return new JsonResult(result);
        }
    }
}
