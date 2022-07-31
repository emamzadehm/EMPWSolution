using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;

namespace PW.UI.Areas.AdminPanel.Pages.SiteManagement.Files
{
    public class IndexModel : PageModel
    {

        private readonly IFileApplication _ifile_application;
        private readonly ICourseApplication _icourse_application;

        public CourseViewModel searchmodelcourse;
        public SelectList courselist;

        public List<FileViewModel> FileVM { get; set; }
        public FileViewModel SearchModel { get; set; }

        public IndexModel(IFileApplication ifile_application, ICourseApplication icourse_application)
        {
            _ifile_application = ifile_application;
            _icourse_application = icourse_application;
        }

        public void OnGet(FileViewModel searchmodel)
        {
            courselist = new SelectList(_icourse_application.Search(), "Id", "Title");
            FileVM = _ifile_application.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            searchmodelcourse = new CourseViewModel();
            var command = new FileViewModel
            {
                CourseList = _icourse_application.Search(searchmodelcourse)
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(FileViewModel filevm)
        {
            var result = _ifile_application.Create(filevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var selecteditem = _ifile_application.GetDetails(id);
            selecteditem.CourseList = _icourse_application.Search(searchmodelcourse);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(FileViewModel filevm)
        {
            var result = _ifile_application.Edit(filevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(FileViewModel filevm)
        {
            _ifile_application.Remove(filevm.Id);
            return RedirectToPage("Index");
        }


    }
}
