using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;

namespace PW.UI.Areas.AdminPanel.Pages.SiteManagement.Resume
{
    public class IndexModel : PageModel
    {

        private readonly IResumeApplication _iresume_application;

        public List<ResumeViewModel> ResumeVM { get; set; }
        public ResumeViewModel SearchModel { get; set; }

        public IndexModel(IResumeApplication iresume_application)
        {
            _iresume_application = iresume_application;
        }

        public void OnGet(ResumeViewModel searchmodel)
        {
            ResumeVM = _iresume_application.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new ResumeViewModel();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(ResumeViewModel resumevm)
        {
            var result = _iresume_application.Create(resumevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var selecteditem = _iresume_application.GetDetails(id);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(ResumeViewModel resumevm)
        {
            var result = _iresume_application.Edit(resumevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(ResumeViewModel resumevm)
        {
            _iresume_application.Remove(resumevm.Id);
            return RedirectToPage("Index");
        }
    }
}