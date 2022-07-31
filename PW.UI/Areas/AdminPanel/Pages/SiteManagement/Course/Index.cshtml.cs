using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;

namespace PW.UI.Areas.AdminPanel.Pages.SiteManagement.Course
{
    public class IndexModel : PageModel
    {

        private readonly ICourseApplication _icourse_application;

        public List<CourseViewModel> CourseVM { get; set; }
        public CourseViewModel SearchModel { get; set; }

        public IndexModel(ICourseApplication icourse_application)
        {
            _icourse_application = icourse_application;
        }

        public void OnGet(CourseViewModel searchmodel)
        {
            searchmodel.ShowInWebSite = false;
            CourseVM = _icourse_application.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CourseViewModel();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CourseViewModel coursevm)
        {
            var result = _icourse_application.Create(coursevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var selecteditem = _icourse_application.GetDetails(id);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(CourseViewModel coursevm)
        {
            var result = _icourse_application.Edit(coursevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(CourseViewModel coursevm)
        {
            _icourse_application.Remove(coursevm.Id);
            return RedirectToPage("Index");
        }

    }
}
